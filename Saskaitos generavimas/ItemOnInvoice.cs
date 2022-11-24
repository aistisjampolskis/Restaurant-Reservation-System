// See https://aka.ms/new-console-template for more information

using RestaurantReservationSystem;



public class ItemOnInvoice
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public string DateTime { get; set; }
    public int PaymentOption { get; set; }
    public string Client { get; set; }
    public List<ListOfItem> Itemss{ get; set; }
    public double InvoiceTotal { get; set; }
    public int QtyTotal { get; set; }

    
    public ItemOnInvoice(int id, string orderNumber, string dateTime, int paymentOption, string client, List<ListOfItem> itemss, double invoiceTotal, int qtyTotal)
    {
        Id = id;
        OrderNumber = orderNumber;
        DateTime = dateTime;
        PaymentOption = paymentOption;
        Client = client;
        Itemss = itemss;
        InvoiceTotal = invoiceTotal;
        QtyTotal = qtyTotal;
    }
}
