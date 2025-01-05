using System;

public class Order
{
    int idOrder { get; set; }
    DateTime dateOrder { get; set; }
    double totalAmount { get; set; }
    string status { get; set; }

    public Order(int idOrder, DateTime dateOrder, double totalAmount, string status)
    {
        this.idOrder = idOrder;
        this.dateOrder = dateOrder;
        this.totalAmount = totalAmount;
        this.status = status;
    }
}
{

}
