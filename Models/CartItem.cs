using System;

public class CartItem
{
    int idCartItem { get; set; }
    int idCart { get; set; }
    int idProduct { get; set; }
    int quantity { get; set; }
    int totalPrice { get; set; }
    public CartItem(int idCartItem, int idCart, int idProduct, int quantity, int totalPrice)
    {
        this.idCartItem = idCartItem;
        this.idCart = idCart;
        this.idProduct = idProduct;
        this.quantity = quantity;
        this.totalPrice = totalPrice;
    }
}
