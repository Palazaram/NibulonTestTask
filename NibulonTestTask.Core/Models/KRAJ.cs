
namespace NibulonTestTask.Core.Models
{
    public class KRAJ
    {
        public int KRAJ_ID { get; set; }
        public string NRAJ { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        public virtual ICollection<AUP> AUPs { get; set; } = new List<AUP>();
    }
}
