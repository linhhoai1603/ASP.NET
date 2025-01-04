using System;

public class OrderItem
{
	int idOrderItem { get; set; }
    int idOrder { get; set; }
    int idProduct { get; set; }
    int quantity { get; set; }
    int totalPrice { get; set; }
    public OrderItem(int idOrderItem, int idOrder, int idProduct, int quantity, int totalPrice)
    {
        this.idOrderItem = idOrderItem;
        this.idOrder = idOrder;
        this.idProduct = idProduct;
        this.quantity = quantity;
        this.totalPrice = totalPrice;
    }
}
