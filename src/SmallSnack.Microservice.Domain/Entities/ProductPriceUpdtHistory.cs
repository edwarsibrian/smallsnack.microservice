using System;
using System.ComponentModel.DataAnnotations;

namespace SmallSnack.Microservice.Domain.Entities
{
    public class ProductPriceUpdtHistory
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public Product Product { get; set; }

        public DateTime Date { get; set; }

        public double OldPrice { get; set; }
    }
}