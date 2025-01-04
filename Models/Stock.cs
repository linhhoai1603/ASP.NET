using System;

public class Stock
{
	int idStock { get; set; }
    int idProduct { get; set; }
    int quantity { get; set; }
    public Stock(int idStock, int idProduct, int quantity)
    {
        this.idStock = idStock;
        this.idProduct = idProduct;
        this.quantity = quantity;
    }


}
