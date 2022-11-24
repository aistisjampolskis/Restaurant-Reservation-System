using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestaurantReservationSystem.Repositories;
using System.Reflection;

namespace RestaurantReservationSystem
{
    public class Receipt
    {
        GetFullInvoisingById getFullInvoisingById = new GetFullInvoisingById();
        InvoiceWithoutItems invoiceWithoutItems = new InvoiceWithoutItems();

        IEmailReceipt receipt;

        public Receipt(IEmailReceipt emailReceipt)
        {
            receipt = emailReceipt;
        }
        public void ReceiptSolution()
        {
            while (true)
            {
                Console.WriteLine("Need receipt for customer [1]\n Don't need receipt [2]\n");
                int action3 = int.Parse(Console.ReadLine());
                if (action3 == 1)
                {
                   var sendMail = new Mail();
                   int passing =  getFullInvoisingById.GetFullINvoiceById();
                    receipt.SentEmail(invoiceWithoutItems.GetHtmlCutomer(invoiceWithoutItems.GetReceipt(passing)));
                    break;
                   
                }
                if (action3 == 2)
                {
                    Console.WriteLine("Enter table ID");
                    int invoiceId = Convert.ToInt32(Console.ReadLine());
                    var sendMail = new Mail();
                    receipt.SentEmail(invoiceWithoutItems.GetHtmlRestaurant(invoiceWithoutItems.GetReceipt(invoiceId)));
                    break;
                }
                break;
            }
        }
    }
}
