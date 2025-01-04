using System;

public class Cart
{
	int idCart { get; set; }
    int idUser { get; set; }
    int totalPrice { get; set; }
    public Cart(int idCart, int idUser, int totalPrice)
    {
        this.idCart = idCart;
        this.idUser = idUser;
        this.totalPrice = totalPrice;
    }
}
