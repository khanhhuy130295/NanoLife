namespace NanoLifeShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int ID_Order { get; set; }
        public int ID_Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ProductViewModel ProductVM { get; set; }
        public virtual OrderViewModel OrderVM { get; set; }
    }
}