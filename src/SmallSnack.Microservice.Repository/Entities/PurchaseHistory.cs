using System.ComponentModel.DataAnnotations;

namespace SmallSnack.Microservice.Repository.Entities
{
    public class PurchaseHistory
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public User User { get; set; }
    }
}