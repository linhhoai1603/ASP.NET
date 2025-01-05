namespace ProjectDotNET.Models
{
    public class Categories
    {
        public int category_id { get; set; }
        public String category_name { get; set; }

        public Categories(int category_id, String category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }
        public Categories()
        {
        }
    }
}
