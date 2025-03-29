using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Application.Services;
using NibulonTestTask.Core.DTO;
using NibulonTestTask.Core.Models;
using OfficeOpenXml;

namespace NibulonTestTask.Controllers
{
    public class AUPController : Controller
    {
        private readonly AUPService _aupService;
        private readonly CityService _cityService;
        private readonly OBLService _oblService;
        private readonly KRAJService _krajService;

        public AUPController(AUPService aupService, CityService cityService, OBLService oblService, KRAJService krajService)
        {
            _aupService = aupService;
            _cityService = cityService;
            _oblService = oblService;
            _krajService = krajService;
        }

        [HttpGet]
        public async Task<IActionResult> AUPs()
        {
            try
            {
                return View(await _aupService.GetAUPsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPostalIndexes(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Файл не завантажено або він порожній." });
            }

            string extension = Path.GetExtension(file.FileName).ToLower();

            if (extension == ".xlsx" || extension == ".xls")
            {
                try
                {
                    var aup = await _aupService.GetAUPsAsync();

                    // При повторному завантаженні даних транкейтим таблицю AUPs
                    if (aup is not null)
                    {
                        await _aupService.TruncateAUPTableAsync();
                    }

                    // Довідники міст, областей та районів
                    var cityList = await _cityService.GetCitiesAsync();
                    var oblList = await _oblService.GetOBLsAsync();
                    var krajList = await _krajService.GetKRAJsAsync();

                    // Використовуємо саме лінкед лист для оптимізації, оскільки багато операцій вставки
                    var result = new LinkedList<AUP>();

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    // Обробка файлу
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets[0];
                            int rowCount = worksheet.Dimension.End.Row;

                            for (int row = 3; row <= rowCount; row++)
                            {
                                var postalIndex = new PostalIndex
                                {
                                    Region = worksheet.Cells[row, 2].Text,
                                    District = worksheet.Cells[row, 4].Text,
                                    City = worksheet.Cells[row, 5].Text,
                                    Index = worksheet.Cells[row, 6].Text
                                };

                                result.AddLast(_aupService.CreateAUPObject(postalIndex, cityList, oblList, krajList));
                            }
                        }
                    }

                    // Булк інсерт всіх даних із файлу
                    await _aupService.AddRangeAsync(result);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest(new { message = "Файл має невірний формат. Завантажте файл з розширенням \".xlsx\" або \".xls\"" });
            }
        }
    }
}
