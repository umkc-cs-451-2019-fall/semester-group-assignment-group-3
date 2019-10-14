using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommerceBank.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int AccountID { get; set; }

        public Account Account { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Processing Date")]
        public DateTime ProcessingDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "CR (Deposit) or DR (Withdrawal)")]
        public string CRorDR { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Description 1")]
        public string Description1 { get; set; }

    }
}

// this is for the migration Add-Migration Transaction 

// this is to update the database Update-Database 