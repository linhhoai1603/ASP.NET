using System;

public class Colors
{
    int color_id { get; set; }
    int product_id { get; set; }
    string color_name { get; set; }
    string color_img { get; set; }
    public Colors(int color_id, int product_id, string color_name, string color_img)
    {
        this.color_id = color_id;
        this.product_id = product_id;
        this.color_name = color_name;
        this.color_img = color_img;
    }
