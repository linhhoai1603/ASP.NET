using System;

public class ProductSpecification
{
    int product_spe_id { get; set; }
    string ram { get; set; }
    string resolution { get; set; }
    string storage_capacity { get; set; }
    public ProductSpecification(int product_spe_id, string ram, string resolution, string storage_capacity)
    {
        this.product_spe_id = product_spe_id;
        this.ram = ram;
        this.resolution = resolution;
        this.storage_capacity = storage_capacity;
    }
}
