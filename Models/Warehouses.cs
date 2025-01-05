using System;

public class Warehouses
{
	int idWarehouse { get; set; }
	string warehouseName { get; set; }
	string address { get; set; }
	int quantity { get; set; }
	int product_id { get; set; }
	public Warehouses(int idWarehouse, string warehouseName, string address, int quantity, int product_id)
    {
        this.idWarehouse = idWarehouse;
        this.warehouseName = warehouseName;
        this.address = address;
        this.quantity = quantity;
        this.product_id = product_id;
    }
}
