using System.ComponentModel.DataAnnotations;

namespace SinavOlusturma.Models
{
    public class Sinav
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public virtual ICollection<Soru> Sorular { get; set; }
    }
}
