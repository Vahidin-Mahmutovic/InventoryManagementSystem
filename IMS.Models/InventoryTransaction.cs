using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


using IMS.Utility.Enums;

namespace IMS.Models
{


    public class InventoryTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int StoreId { get; set; }

        [ForeignKey("StoreId")]
        public Store Store { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }

        [StringLength(100)]
        public string? PerformedBy { get; set; }
    }
}
