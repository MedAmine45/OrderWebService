using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebAPIPerspection.Models;

namespace WebAPIPerspection.Controllers
{
    public class EmailState
    {
        private  EmailSettings _emailSetting;
        private readonly string UrlPay = "https://epayments-support.ingenico.com/fr/integration/all-sales-channels/";

        public EmailState(EmailSettings setting)
        {
            _emailSetting = setting;
        }
        public void EnvoieEmail(Prescription prescription, string newState)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailSetting.UseSsl;
                smtpClient.Host = _emailSetting.ServerName;
                smtpClient.Port = _emailSetting.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSetting.Username, _emailSetting.Password);
                StringBuilder body = new StringBuilder();
                                              //.AppendLine("A new order has been submitted ")
                                              //.AppendLine("---------------------------------------------------------------------------------------------------------");
                if(newState == StateEnum.Prescribed.ToString())
                {
                    body.AppendLine(" ")
                        .AppendFormat("dear patient {0} {1}, you should  go to the website page which has the link below to pay",prescription.Patient.Firstname,prescription.Patient.Lastname)
                        .AppendLine("")
                        .AppendLine("---------------------------------------------------------------------------------------------------------")
                        .AppendLine("Website Url")
                        .AppendLine(UrlPay);
                }else if(newState == StateEnum.Ordered.ToString())
                {
                    body.AppendLine(" ")
                      .AppendFormat("dear patient {0} {1}, Thanks for your order. ", prescription.Patient.Firstname, prescription.Patient.Lastname)
                      .AppendLine("")
                      .AppendLine("---------------------------------------------------------------------------------------------------------")
                      .AppendLine("the kit will be sent");
                } else if(newState == StateEnum.Sent.ToString())
                {
                    body.AppendLine(" ")
                      .AppendFormat("dear patient {0} {1}, Thanks for your order. ", prescription.Patient.Firstname, prescription.Patient.Lastname)
                      .AppendLine("")
                      .AppendLine("---------------------------------------------------------------------------------------------------------")
                      .AppendLine("Your  order has been sent");
                }else if(newState == StateEnum.Samplesreceived.ToString())
                {
                    body.AppendLine(" ")
                     .AppendFormat("dear patient {0} {1}, Thanks for your order.  ", prescription.Patient.Firstname, prescription.Patient.Lastname)
                     .AppendLine("")
                     .AppendLine("---------------------------------------------------------------------------------------------------------")
                     .AppendLine("samples have been received will be analyzed");
                }
                MailMessage mailMessage = new MailMessage(_emailSetting.MailFromAddress, prescription.Patient.Email, "followed Prescription", body.ToString());
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }

            }

        }
    }
}
