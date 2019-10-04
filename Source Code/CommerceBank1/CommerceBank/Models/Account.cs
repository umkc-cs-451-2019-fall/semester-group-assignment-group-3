using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceBank.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Balance { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
    }
}

// this is for the migration Add-Migration Account 

// this is to update the database Update-Database 