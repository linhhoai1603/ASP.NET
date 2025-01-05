using System;

public class DetailProduct
{
    int idDetailProduct { get; set; }
    string ram { get; set; }
    string resolution { get; set; }
    string storageCapacity { get; set; }

    public DetailProduct(int idDetailProduct, string ram, string resolution, string storageCapacity)
    {
        this.idDetailProduct = idDetailProduct;
        this.ram = ram;
        this.resolution = resolution;
        this.storageCapacity = storageCapacity;
    }
}



