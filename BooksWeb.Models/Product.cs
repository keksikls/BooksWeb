using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BooksWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1 , 1000)] //далАры
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1 - 50+")]
        [Range(1, 1000)] 
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)] 
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)] 
        public double Price100 { get; set; }

        //связываем внешний ключ с таблицей + category и product
        public int CategoryId { get; set; } // ключ для столбца для связывания в Product
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }//явно связываем 
        [ValidateNever]
        public string  ImageUrl { get; set; }

    }
}
