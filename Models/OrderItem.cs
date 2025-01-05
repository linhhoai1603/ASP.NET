using System;

public class OrderItem
{
	int idOrderItem { get; set; }
    int idOrder { get; set; }
    double price { get; set; }
    int quantity { get; set; }
    int idProduct { get; set; }
    int totalPrice { get; set; }
  public OrderItem(int idOrderItem, int idOrder, double price, int quantity, int idProduct, int totalPrice)
    {
        this.idOrderItem = idOrderItem;
        this.idOrder = idOrder;
        this.price = price;
        this.quantity = quantity;
        this.idProduct = idProduct;
        this.totalPrice = totalPrice;
    }
}
