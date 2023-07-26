using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models.Request;
using Domain.Models;
using Shared.Result;

namespace Application.Services
{
    public class EmailService : IEmailService
    {


        private void Dispose(bool disposing) 
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Result<bool>> SendEmail(Email email, EmailCredentials credentials)
        {

            try
            {

                var mail = new MailMessage();
                mail.From = new MailAddress(credentials.User);
                mail.To.Add(email.To);
                                
                byte[] data = Convert.FromBase64String(email.Content);
                string decodedString = Encoding.UTF8.GetString(data);
                if(!string.IsNullOrWhiteSpace(email.Cc))
                    email.Cc.Split(',').ToList().ForEach(i => mail.CC.Add(i));
                mail.Body = decodedString;
                mail.IsBodyHtml = email.HtmlContent;
                mail.Subject = email.Subject;
                

                using ( SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(credentials.User, credentials.Password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }                
                return new Shared.Result.CreatedResult<bool>(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new BadRequestResult<bool>(false);
            }
            
        }
    }
}