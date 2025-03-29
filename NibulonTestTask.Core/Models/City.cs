
namespace NibulonTestTask.Core.Models
{
    public class City
    {
        public string CITY_KOD { get; set; }
        public string CITY { get; set; }

        public int? KRAJ_KOD { get; set; } // Посилання на KRAJ
        public virtual KRAJ? Kraj { get; set; }

        public int? OBL_KOD { get; set; } // Посилання на OBL
        public virtual OBL? Obl { get; set; }

        public virtual ICollection<AUP> AUPs { get; set; } = new List<AUP>();
    }
}
