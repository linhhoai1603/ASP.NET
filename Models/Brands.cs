using System;

public class Brands
{
	int idBrand { get; set; }
	string brandName { get; set; }
	public Brands(int idBrand, string brandName)
    {
        this.idBrand = idBrand;
        this.brandName = brandName;
    }

}
