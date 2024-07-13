using System;
using System.ComponentModel.DataAnnotations;

namespace NestAway.Web.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }

        public string ReceiverId { get; set; }
        public User Receiver { get; set; }

        public double Amount { get; set; }

        [Display(Name = "Date of Transaction")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDateTime { get; set; }

        public Transaction()
        {
            this.TransactionDateTime = DateTime.Now;
        }
    }
}
