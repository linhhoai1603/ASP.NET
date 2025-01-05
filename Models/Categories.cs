using System;

public class Categories
{
    int category_id { get; set; }
    string category_name { get; set; }
    public Categories(int category_id, string category_name)
    {
        this.category_id = category_id;
        this.category_name = category_name;
    }
}
