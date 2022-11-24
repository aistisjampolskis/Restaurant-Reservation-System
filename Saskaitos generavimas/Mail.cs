using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem
{
    public class Mail : IEmailReceipt
    {
        public virtual string SentEmail(string fileName)
        {
            {
                if (fileName != null)
                {
                    MailAddress to = new MailAddress("jonas@jonas.lt");
                    MailAddress from = new MailAddress("petras@petras.lt");
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = "Restaurant Receipt";
                    message.Body = "In the attachment you will find receipt";
                    message.Attachments.Add(new Attachment(fileName));
                    message.IsBodyHtml = true;
                    var client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("6118628b74f2e4", "ee0f83d0b6a419"),
                        EnableSsl = true
                    };
                    try
                    {
                        client.Send(message);

                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Console.WriteLine("Sent");
                    return fileName;
                }
                else
                {
                    Console.WriteLine("Sorry nothing to send, wrong table");
                    return null;
                }
            }
        }
    }
}
