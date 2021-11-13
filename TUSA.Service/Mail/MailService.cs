using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service.Mail
{
    public interface IMailService:IBaseService<group_master>
    {
        bool sendGroupFormLink(string toMail, string groupName, string OrgName, int RequesrId);
    }
   public class MailService:BaseService<group_master>, IMailService
    {
        public MailService(IUnitOfWork uow) : base(uow)
        {

        }
        public bool sendGroupFormLink(string toMail, string groupName,string OrgName,int RequestId)
        {
             //ToMail="harijonnalagadda@gmail.com";
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("support@triptychusa.com", "Tickets42me+U"),
                EnableSsl = true,
            };
            string FormLink = string.Format("http://localhost:4500/tusa/master-screens/supplier-registration?email_Id=" + toMail);
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

            pending_groups groups= _UOW.GetRepository<pending_groups>().Get(x => x.ID == RequestId).FirstOrDefault();
            pending_groups_mails mail = new pending_groups_mails();
            mail.mail_sendedat = DateTime.Now;
            mail.mail_status = true;
            mail.pending_Groups = groups;
            _UOW.GetRepository<pending_groups_mails>().Update(mail);
            _UOW.SaveChanges();

            return true;
        }
    }
}
