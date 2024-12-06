using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DAL.Entities
{
    public class PaymentProcess : IEntity
    {
        public int ID { get; set; }
        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string UserId { get; set; } // FK to ApplicationUser
        public virtual Users User { get; set; } // Navigation property

        public string productName { get; set; }
     
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string PaymentMethod { get; set; }

        public string NameOnCard { get; set; }

        public string CreditCardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public string Cvv { get; set; }

        public string Status { get; set; }


    }
}
