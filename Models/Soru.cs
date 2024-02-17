using System.ComponentModel.DataAnnotations;

namespace SinavOlusturma.Models
{
    public class Soru
    {
        [Key]
        public int Id { get; set; }
        public string soruMetni { get; set; }
        public string secenekA { get; set; }
        public string secenekB { get; set; }
        public string secenekC { get; set; }
        public string secenekD { get; set; }
        public string dogruCevap { get; set; }
        public int SinavId { get; set; }
        public virtual Sinav Sinav { get; set; }
    }
}
