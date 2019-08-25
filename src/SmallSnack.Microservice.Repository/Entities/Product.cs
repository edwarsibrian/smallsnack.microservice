using System.ComponentModel.DataAnnotations;

namespace SmallSnack.Microservice.Repository.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }

        public int Linking { get; set; }

    }
}