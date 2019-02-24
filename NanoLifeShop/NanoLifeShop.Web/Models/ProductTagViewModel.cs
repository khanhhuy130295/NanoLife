namespace NanoLifeShop.Web.Models
{
    public class ProductTagViewModel
    {

        public int IDProduct { get; set; }


        public string IDTag { get; set; }


        public virtual ProductViewModel Product { get; set; }


        public virtual TagViewModel Tag { get; set; }
    }
}