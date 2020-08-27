using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
<<<<<<< HEAD
using System.Threading.Tasks;
using GoToWorkBusinessLogic.HelperModels;
using MailKit.Net.Pop3;
using MailKit.Security;
=======
using GoToWorkBusinessLogic.HelperModels;
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152

namespace GoToWorkBusinessLogic.BusinessLogics
{
    public static class MailLogic
    {
        private static string smtpClientHost;
        private static int smtpClientPort;
        private static string mailLogin;
        private static string mailPassword;
        public static void MailConfig(MailConfig config)
        {
            smtpClientHost = config.SmtpClientHost;
            smtpClientPort = config.SmtpClientPort;
            mailLogin = config.MailLogin;
            mailPassword = config.MailPassword;
        }
        public static async void MailSendAsync(MailSendInfo info)
        {
            if (string.IsNullOrEmpty(smtpClientHost) || smtpClientPort == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(mailLogin) || string.IsNullOrEmpty(mailPassword))
            {
                return;
            }
            if (string.IsNullOrEmpty(info.MailAddress))
            {
                return;
            }
            using (var objMailMessage = new MailMessage())
            {
                using (var objSmtpClient = new SmtpClient(smtpClientHost, smtpClientPort))
                {
                    try
                    {
                        objMailMessage.From = new MailAddress(mailLogin);
                        objMailMessage.To.Add(new MailAddress(info.MailAddress));
                        objMailMessage.Attachments.Add(new Attachment(info.FileName));
                        objMailMessage.SubjectEncoding = Encoding.UTF8;
                        objMailMessage.BodyEncoding = Encoding.UTF8;
                        objSmtpClient.UseDefaultCredentials = false;
                        objSmtpClient.EnableSsl = true;
                        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        objSmtpClient.Credentials = new NetworkCredential(mailLogin, mailPassword);
                        objSmtpClient.Send(objMailMessage);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}