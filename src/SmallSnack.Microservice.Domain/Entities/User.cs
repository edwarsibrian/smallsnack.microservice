using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmallSnack.Microservice.Domain.Enums;

namespace SmallSnack.Microservice.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public string Password { get; set; }
        
        public IEnumerable<PurchaseHistory> PurchaseHistories { get; set; }
    }
}