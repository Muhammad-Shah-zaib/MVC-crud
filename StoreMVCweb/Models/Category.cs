using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVCweb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [DisplayName("Display order")]
        [Required]
        [Range(1,1000)]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
