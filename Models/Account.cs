using System;

public class Account
{
    int idAccount { get; set; }
    string password { get; set; }
    int role { get; set; }
    public Account(int idAccount, string password, int role)
    {
        this.idAccount = idAccount;
        this.password = password;
        this.role = role;
    }
}
