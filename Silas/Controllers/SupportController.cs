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
            bool isSent = await SendEmailAsync("proyectosilasdev@gmail.com", request.Topic, request.Message, request.CompanyName, request.Contact);

            return Json(new { success = isSent });
        }

        private async Task<bool> SendEmailAsync(string toEmail, string subject, string body, string companyName, string contact)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("proyectosilasdev@gmail.com", "utpjbyffrilrumcm"), 
                    EnableSsl = true
                };

                // Cuerpo del correo electronico
                var emailBody = $@"
                <html>
    <head>
        <style>
            body {{
                font-family: 'Arial', sans-serif;
                background-color: #f9f9f9;
                margin: 0;
                padding: 0;
                box-sizing: border-box;
            }}
                
a {{
text-decoration: none;
color:white;
}}

            h1 {{
                color: #d32f2f; /* Red color */
                font-size: 28px;
                font-weight: bold;
                text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.1);
                margin-bottom: 10px;
            }}

            .header {{
                background-color: red; /* Light pink background */
                padding: 10px;
                text-align: center;
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
                margin-bottom: 30px;
                box-shadow:0px 0px 10px;
            }}

            .header h1 {{
                font-size: 36px;
                color: white; /* Pink color */
                letter-spacing: 2px;
            }}

            .content {{
                background-color:#abb8c3; /* White background */
                padding: 20px;
                margin: 0 auto;
                width: 80%;
                max-width: 600px;
                border-radius: 8px;
                box-shadow: 0px 4px 16px rgba(0, 0, 0, 0.1);
                margin-bottom: 30px;
            }}

            .content p {{
                font-size: 16px;
                line-height: 1.6;
                color: #333;
            }}

            .content p strong {{
                color: black; /* Red color for important text */
            }}

            .footer {{
                font-size: 14px;
                color: #888;
                text-align: center;
                margin-top: 30px;
                border-top: 1px solid #eee;
                padding-top: 10px;
            }}

            .footer p {{
                margin: 5px 0;
            }}

            .footer a {{
                color: #d32f2f;
                text-decoration: none;
                font-weight: bold;
            }}

            .button {{
                display: inline-block;
                background-color: #e91e63; /* Pink color */
                color: white;
                padding: 10px 20px;
                border-radius: 5px;
                text-decoration: none;
                font-size: 16px;
                margin-top: 20px;
                text-align: center;
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
                transition: background-color 0.3s ease;
            }}

            .button:hover {{
                background-color: #c2185b; /* Darker pink */
            }}
        </style>
    </head>
    <body>
        <div class=""header"">
            <h1>SILAS Soporte</h1>
        </div>

        <div class=""content"">
            <h2>Soporte para la empresa: {companyName}</h2>
            <p><strong>Asunto:</strong> {subject}</p>
            <p><strong>Mensaje:</strong> {body}</p>
            <p><strong>Contacto:</strong> {contact}</p>

            <a href=""mailto:{contact}"" class=""button"">Responder</a>
        </div>

        <div class=""footer"">
            <p>Este mensaje fue enviado desde el sistema de soporte para <strong>{companyName}</strong>.</p>
           
        </div>
    </body>
</html>
";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("proyectosilasdev@gmail.com"),
                    Subject = subject,
                    Body = emailBody,
                    IsBodyHtml = true 
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }
    }


    public class SupportRequest
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public string CompanyName { get; set; }
        public string Contact { get; set; }
    }
}
