using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallSnack.Microservice.Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }

        public int Linking { get; set; }

        [NotMapped]
        public IEnumerable<ProductPriceUpdtHistory> ProductPriceUpdtHistories { get; set; }

    }
}