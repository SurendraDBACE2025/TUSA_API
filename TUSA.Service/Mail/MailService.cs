using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Status;
using TUSA.Domain.Models.User;

namespace TUSA.Service.Mail
{
    public interface IMailService:IBaseService<group_master>
    {
        void sendGroupFormLink(string toMail);
        void sendUserFormLinkAsync(user_creation_request request);
    }
   public class MailService:BaseService<group_master>, IMailService
    {
        private IConfiguration _configuration;
        public MailService(IUnitOfWork uow , IConfiguration Configuration) : base(uow)
        {
            _configuration = Configuration;
        }
        public  async void sendGroupFormLink(string toMail)
        {
          
             //ToMail="harijonnalagadda@gmail.com";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                // Credentials = new NetworkCredential("support@triptychusa.com", "Tickets42me+U"),
                Credentials = new NetworkCredential("idbace@gmail.com", "Dbace$123"),
                EnableSsl = true,
            };
            string FormLink = string.Format("http://localhost:4500/tusa/master-screens/supplier-registration?email_id=" + toMail);
            string HtmlBody = "<html>Dear Valued Supplier,</br></br>Below is the link  for to update details</br></br>" +
                FormLink+ "</br></br>Regards,</br>TripTych Support</html>";

            var mailMessage = new MailMessage
            {
                From = new MailAddress("support@triptychusa.com", "Support Triptych USA"),
                Subject = "Re-Visit Required for Shell Data",
                Body = HtmlBody,
                IsBodyHtml = true,
            };
          
            mailMessage.To.Add(toMail);

           await smtpClient.SendMailAsync(mailMessage);

            // updating mail status in database
            try
            {
                MailUpdate(toMail);
            }
            catch { }
        }
        public async void sendUserFormLinkAsync(user_creation_request request)
        {
            foreach (user_craetion user in request.users)
            {
                //ToMail="harijonnalagadda@gmail.com";
                var smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("support@triptychusa.com", "Tickets42me+U"),
                    EnableSsl = true,
                };
                string FormLink = string.Format("http://localhost:4500/tusa/master-screens/user-creation?email_id=" + user.email_Id);
                string HtmlBody = "<html>Dear Valued Supplier,</br></br>Below is the link  for to update details</br></br>" +
                    FormLink + "</br></br>Regards,</br>TripTych Support</html>";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("support@triptychusa.com", "Support Triptych USA"),
                    Subject = "Re-Visit Required for Shell Data",
                    Body = HtmlBody,
                    IsBodyHtml = true,
                };

                // ms.Position = 0;
                //Attachment att1 = new Attachment(ms, fileName);
                //att1.ContentType = new System.Net.Mime.ContentType("application/vnd.ms-excel");
                //mailMessage.Attachments.Add(att1);
                //mailMessage.Attachments.Add(Attachment.CreateAttachmentFromString(JSonData, "application/json"));
                //mailMessage.Attachments.Last().ContentDisposition.FileName = fileName;
                mailMessage.To.Add(user.email_Id);
               
                //await smtpClient.SendMailAsync(mailMessage);

                // updating mail status in database
                try
                {
                    MailUpdate(user.email_Id);
                }
                catch { }

                // return true;
            }
        
        }


        public bool MailUpdate(string mailId)
        {
            try
            {
                SqlConnection cn = new SqlConnection(this._configuration.GetConnectionString("TUSADB"));

                using (SqlCommand cmd = new SqlCommand("INSERT INTO mails_status (email_id,status,sendedat) VALUES (@email, @status, @sendedat)", cn))
                {
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = mailId;
                    cmd.Parameters.Add("@status", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@sendedat", SqlDbType.DateTime).Value =DateTime.Now;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
