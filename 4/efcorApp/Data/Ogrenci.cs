using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace efcorApp.Data
{
    public class Ogrenci
    {
        //primary key
        [Key]
        [HtmlAttributeName("Id")]
        public int OgrenciId { get; set; }

        [Required]
        public string? OgrenciAd { get; set; }
        [Required]
        public string? OgrenciSoyad { get; set; }
        [EmailAddress]
        public string? OgrenciEmail { get; set; }
        [Phone]
        public string? OgrenciTelefon { get; set; }
        
        public ICollection<KursKayit> KursKayitlar { get; set; }=new List<KursKayit>();





    }
}