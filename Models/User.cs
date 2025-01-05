using System;

public class User
{
    int idUser { get; set; }
    string username { get; set; }
    string passWord { get; set; }
    int role { get; set; }
    string address { get; set; }
    string phone { get; set; }
    string email { get; set; }
    string fullName { get; set; }
   public User(int idUser, string username, string passWord, int role, string address, string phone, string email, string fullName)
    {
        this.idUser = idUser;
        this.username = username;
        this.passWord = passWord;
        this.role = role;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.fullName = fullName;
    }


}
