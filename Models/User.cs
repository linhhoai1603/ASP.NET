using System;

public class User
{
    int idUser { get; set; }
    string username { get; set; }
    string email { get; set; }
    string phone { get; set; }
    string address { get; set; }
    int idAccount { get; set; }
    int fullName { get; set; }
    public
        User(int idUser, string username, string email, string phone, string address, int idAccount, int fullName)
    {
        this.idUser = idUser;
        this.username = username;
        this.email = email;
        this.phone = phone;
        this.address = address;
        this.idAccount = idAccount;
        this.fullName = fullName;
    }
}
