using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;

namespace Silas.Controllers
{
    public class SupportController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SendSupportRequest([FromBody] SupportRequest request)
        {
            bool isSent = await SendEmailAsync("proyectosilasdev@gmail.com", request.Topic, request.Message);

            return Json(new { success = isSent });
        }

        private async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("proyectosilasdev@gmail.com", "utpjbyffrilrumcm"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("proyectosilasdev@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class SupportRequest
    {
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
