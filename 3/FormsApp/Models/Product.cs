using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal? Price { get; set; }
        [Display(Name = "Image")]
     
        public string? Image { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }
        [Display(Name ="IsActive")]
        public bool IsActive { get; set; }



    }
}