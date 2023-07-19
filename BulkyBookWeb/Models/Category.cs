using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display must be between..")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTim { get; set; } = DateTime.Now;
    }
}
