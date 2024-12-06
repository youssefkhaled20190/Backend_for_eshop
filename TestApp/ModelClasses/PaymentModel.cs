using TestApp.DAL.Entities;

namespace TestApp.ModelClasses
{
    public class PaymentModel
    {
        public int ID { get; set; }
        //public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
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
        public string status { get; set; }
    }
}
