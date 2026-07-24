namespace Assignment_11.Models
{
    public class Products
    {
        public int id { get; set; }
        required
        public string name { get; set; }
        public double price { get; set; }
        public bool isFavorite { get; set; }
        public bool available { get; set; }
    }
}
