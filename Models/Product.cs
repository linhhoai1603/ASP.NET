using System;

public class Product
{
    int idProduct { get; set; }
    string productName { get; set; }
    double unitPrice { get; set; }
    string description { get; set; }
    int idBrand { get; set; }
    int category_id { get; set; }
    string img_url { get; set; }

    public Product(int idProduct, string productName, double unitPrice, string description, int idBrand, int category_id, string img_url)
    {
        this.idProduct = idProduct;
        this.productName = productName;
        this.unitPrice = unitPrice;
        this.description = description;
        this.idBrand = idBrand;
        this.category_id = category_id;
        this.img_url = img_url;
    }
