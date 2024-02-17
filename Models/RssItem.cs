using System.ComponentModel.DataAnnotations;

namespace SinavOlusturma.Models
{
    public class RssItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }
}
