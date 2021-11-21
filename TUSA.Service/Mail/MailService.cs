using System;
using System.Collections.Generic;
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
        bool sendGroupFormLink(string toMail);
        void sendUserFormLinkAsync(user_creation_request request);
    }
   public class MailService:BaseService<group_master>, IMailService
    {
        public MailService(IUnitOfWork uow) : base(uow)
        {
           
        }
        public  bool sendGroupFormLink(string toMail)
        {
          
             //ToMail="harijonnalagadda@gmail.com";
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("support@triptychusa.com", "Tickets42me+U"),
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
            
           // ms.Position = 0;
            //Attachment att1 = new Attachment(ms, fileName);
            //att1.ContentType = new System.Net.Mime.ContentType("application/vnd.ms-excel");
            //mailMessage.Attachments.Add(att1);
            //mailMessage.Attachments.Add(Attachment.CreateAttachmentFromString(JSonData, "application/json"));
            //mailMessage.Attachments.Last().ContentDisposition.FileName = fileName;
            mailMessage.To.Add(toMail);
            smtpClient.Send(mailMessage);

            mails_status mail = new mails_status();
            mail.sendedat = DateTime.Now;
            mail.status = true;
            mail.email_Id = toMail;
            _UOW.GetRepository<mails_status>().Update(mail);
            _UOW.SaveChanges();

            return true;
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
                //using (var smtpClient = new SmtpClient("smtp.office365.com")
                //{
                //    Port = 587,
                //    Credentials = new NetworkCredential("support@triptychusa.com", "Tickets42me+U"),
                //    EnableSsl = true,
                //};
                //{
                //    await smtpClient.SendMailAsync(message);
                //}
                await smtpClient.SendMailAsync(mailMessage);

                //mails_status mail = new mails_status();
                //mail.sendedat = DateTime.Now;
                //mail.status = true;
                //mail.email_Id = user.email_Id;
                //_UOW.GetRepository<mails_status>().Update(mail);
                //_UOW.SaveChanges();

                // return true;
            }
        
        }
    }
}
