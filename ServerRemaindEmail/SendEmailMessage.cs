using System.ComponentModel;
using System.Net.Mail;
using System.Net;

namespace ServerRemaindEmail
{
    class SendEmailMessage
    {
        BackgroundWorker bw;
        int ID;
        string email;
        bool isSendEmail;
        public SendEmailMessage(int id, string email)
        {
            this.ID = id;
            this.email = email;
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = false;
            bw.RunWorkerAsync();
        }

        public bool GetisSendEmail()
        {
            return isSendEmail;
        }

        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            SendMail();
        }

        public bool SendMail()
        {
            if (email == null) return false;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("YOUR_EMAIL@gmail.com");
                mail.To.Add("PATIENTS_EMAIL@gmail.com"    /*this.email*/);
                mail.Subject = "Hello";
                mail.Body = "<h1>You have an appointment today</h1>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("YOUR_EMAIL@gmail.com", "PASSWORD");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    
                    return true;
                }   
            }
        }
    }
}
