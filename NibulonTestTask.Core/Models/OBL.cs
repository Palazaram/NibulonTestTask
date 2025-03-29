
namespace NibulonTestTask.Core.Models
{
    public class OBL
    {
        public int KOBL { get; set; }
        public string NOBL { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        public virtual ICollection<AUP> AUPs { get; set; } = new List<AUP>();
    }
}
