using System;

public class Product
{
	int idProduct { get; set; }
    string name { get; set; }
    int price { get; set; }
    string description { get; set; }
    string nameBrand { get; set; }
    int idDetailProduct { get; set; }
    public Product(int idProduct, string name, string description, int price, string Description, string nameBrand, int idDetailProduct)
    {
        this.idProduct = idProduct;
        this.name = name;
        this.description = Description;
        this.price = price;
        this.nameBrand = nameBrand;
        this.idDetailProduct = idDetailProduct;
    }


}
