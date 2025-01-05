using System;

public class Admin
{
	int idAdmin { get; set; }
    int idStock { get; set; }
    int idAccount { get; set; }
    public Admin(int idAdmin, int idStock, int idAccount)
    {
        this.idAdmin = idAdmin;
        this.idStock = idStock;
        this.idAccount = idAccount;
    }
}
