namespace ProjectDotNET.Models
{
    public class Users
    {
        public int user_id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public int role { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String fullname { get; set; }
        public Users(int user_id, String username, String password, int role, String address, String phone, String email, String fullname)
        {
            this.user_id = user_id;
            this.username = username;
            this.password = password;
            this.role = role;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.fullname = fullname;
        }
        public Users()
        {
        }
    }
}
