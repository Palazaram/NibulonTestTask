
namespace NibulonTestTask.Core.Models
{
    public class AUP
    {
        public int ID { get; set; }
        public string INDEX_A { get; set; }

        public string? CITY_KOD { get; set; } // Посилання на City
        public virtual City? City { get; set; }

        public int? OBL_KOD { get; set; } // Посилання на Obl
        public virtual OBL? Obl { get; set; }

        public int? RAJ_KOD { get; set; } // Посилання на KRAJ
        public virtual KRAJ? Kraj { get; set; }
    }
}
