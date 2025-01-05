using System;

public class Order
{
    int idOrder { get; set; }
    int idUser { get; set; }
    int totalPrice { get; set; }
    string state { get; set; }
    DateTime dateOrder { get; set; }

    public Order(int idOrder, int idUser, int totalPrice, string state, DateTime dateOrder)
    {
        this.idOrder = idOrder;
        this.idUser = idUser;
        this.totalPrice = totalPrice;
        this.state = state;
        this.dateOrder = dateOrder;
    }
{

}
