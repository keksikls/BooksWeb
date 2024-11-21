using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(15)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1 , 20 , ErrorMessage = "Вы вышли за границу предела")]
        public int DisplayOrder { get; set; }
        
    }
}
