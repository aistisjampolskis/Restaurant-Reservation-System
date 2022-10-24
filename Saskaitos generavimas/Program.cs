// See https://aka.ms/new-console-template for more information
using Saskaitos_generavimas.Entities;
using Saskaitos_generavimas.Repositories;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.ComponentModel;
using Saskaitos_generavimas;
using System.Text;
using QuickType;
using System.Linq;
using System.Collections.Immutable;
using System.Diagnostics;

bool toDoProgram = true;
ItemsRepository itemsRepository = new ItemsRepository();
CustomerRepository customerRepository = new CustomerRepository();
InvoiceItem invoiceItem = new InvoiceItem();
ItemsOnInvoiceRepository itemsOnInvoiceRepository = new ItemsOnInvoiceRepository();
ListOfItem listOfItem = new ListOfItem();
RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
RandomNumberGenerator n = new RandomNumberGenerator();
CustomerFileRead customerFileRead = new CustomerFileRead();
CustomerFileReadValidation customerFileReadValidation = new CustomerFileReadValidation();
ItemReadListAddSaveInvoice itemReadListAddSaveInvoice = new ItemReadListAddSaveInvoice();
CreatingCustomer creatingCustomer = new CreatingCustomer();
CreatingItem creatingItem = new CreatingItem();
ItemRaportation itemRaportation = new ItemRaportation();
CustomerRaportation customerRaportation = new CustomerRaportation();
InvoicingRaportation invoicingRaportation = new InvoicingRaportation();
GetFullInvoisingById getFullInvoisingById = new GetFullInvoisingById();

Init();
 void Init()
{
    while (toDoProgram)
    {
        Console.WriteLine("[1] Create Invoice\n[2] Create item\n[3] Create customer\n[4] Invoice Raport \n[5] Item Raport\n[6] Customer Raport \n[7] See Invoice by ID\n[8] Finish the program");
        int action = int.Parse(Console.ReadLine());
        switch (action)
        {
            case 1:
                itemReadListAddSaveInvoice.ItemReadListAddSaveInvoice2();
                break;
            case 2:
                creatingItem.CreatingItem2();
                break;
            case 3:
                creatingCustomer.CreateCustomer2();
                break;
            case 4:
                invoicingRaportation.InvoiceRaport();
                break;
            case 5:
                itemRaportation.ItemRaport();
                break;
            case 6:
                customerRaportation.CustomerRaport();
                break;
            case 7:
                getFullInvoisingById.GetFullINvoiceById();
                break;
            case 8:
                toDoProgram = false;
                break;
            default:
                Console.WriteLine("Such options does not exist");
                break;
        }
    }
}


