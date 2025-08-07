using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace efcorApp.Data
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }

        [Required]
        public string? Baslik { get; set; }

        public ICollection<KursKayit> KursKayitlar { get; set; }=new List<KursKayit>();
    }
}