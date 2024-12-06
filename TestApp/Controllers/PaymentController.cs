using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TestApp.DAL.Entities;
using TestApp.Helper;
using TestApp.ModelClasses;
using TestApp.PLL.Interfaces;
using TestApp.PLL.Repositories;

namespace TestApp.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentRepository paymentRepository , IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<PaymentModel>>> ShowAllPayments()
        {
            var Payments = await _paymentRepository.GetAll();

            var paymentModal = _mapper.Map<IEnumerable<PaymentModel>>(Payments);

            return Ok(paymentModal);
        }

        [HttpPost]
        public async Task<ActionResult<List<PaymentModel>>> AddNewPayment([FromBody] PaymentModel paymentModel)
        {
            var PaymentEntity = _mapper.Map<PaymentProcess>(paymentModel);
            await _paymentRepository.Add(PaymentEntity);
            await SendConfirmationEmail(paymentModel.Email);
            return Ok(new List<PaymentModel>());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PaymentModel>>> UpdatePayment([FromBody] PaymentModel paymentModel, int id)
        {

            if (id != paymentModel.ID)
            {
                return BadRequest("ID mismatch");
            }

            var existingPayment = await _paymentRepository.GetById(id);
            if (existingPayment == null)
            {
                return NotFound("Order not found");
            }
            existingPayment.Status = paymentModel.status;
            await _paymentRepository.Update(existingPayment);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<PaymentModel>>> DeletePayment(int id)
        {
            var result = await _paymentRepository.DeleteById(id);
            if (result == 0)
            {
                return NotFound("Product not found");
            }

            return NoContent();
        }

        private async Task SendConfirmationEmail(string userEmail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("E-Shop", "E-shopcompany@contact.com"));
                message.To.Add(new MailboxAddress(userEmail, userEmail));  // Add user email properly
                message.Subject = "Payment Confirmation";

                message.Body = new TextPart("plain")
                {
                    Text = "Your payment has been successfully processed. Thank you for your purchase!"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false); // Use TLS for Gmail
                    await client.AuthenticateAsync("yk434182@gmail.com", "fuuoztvkmtxriodi"); // Use App Password if 2FA is enabled
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle appropriately
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }



    }
}
