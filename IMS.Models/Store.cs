using System.ComponentModel.DataAnnotations;

namespace IMS.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Location { get; set; }
    }
}
