using System;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Transaction
    {
       [Key]
       public string TransactionID { get; set; }
       public decimal Amount { get; set; }
       public DateTime Date { get; set; }
       public Appointment Appointment { get; set; } 
    }
}