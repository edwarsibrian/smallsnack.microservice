using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallSnack.Microservice.Repository.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        public IEnumerable<PurchaseHistory> PurchaseHistories { get; set; }
    }
}