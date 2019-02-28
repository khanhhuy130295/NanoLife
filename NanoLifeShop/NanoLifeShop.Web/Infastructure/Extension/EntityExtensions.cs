using NanoLifeShop.Models.Entity;
using NanoLifeShop.Web.Models;

namespace NanoLifeShop.Web.Infastructure.Extension
{
    public static class EntityExtensions
    {
        #region PostCate and Post

        public static void UpdatePostCategory(this PostCategory postCateDB, PostCategoryViewModel viewModel)
        {
            postCateDB.ID = viewModel.ID;
            postCateDB.Name = viewModel.Name;
            postCateDB.Description = viewModel.Description;
            postCateDB.Alias = viewModel.Alias;
            postCateDB.DisplayOder = viewModel.DisplayOder;
            postCateDB.HomeFlag = viewModel.HomeFlag;
            postCateDB.IdParent = viewModel.IdParent;
            postCateDB.Image = viewModel.Image;

            //System Log
            postCateDB.CreateBy = viewModel.CreateBy;
            postCateDB.CreateDate = viewModel.CreateDate;
            postCateDB.MetaDescriptions = viewModel.MetaDescriptions;
            postCateDB.MetaKeyWord = viewModel.MetaKeyWord;
            postCateDB.MetaTitle = viewModel.MetaTitle;
            postCateDB.UpdateBy = viewModel.UpdateBy;
            postCateDB.UpdateDate = viewModel.UpdateDate;
            postCateDB.Status = viewModel.Status;
        }

        public static void UpdatePost(this Post postDB, PostViewModel postVM)
        {
            postDB.ID = postVM.ID;
            postDB.Name = postVM.Name;
            postDB.Alias = postVM.Alias;
            postDB.Description = postVM.Description;
            postDB.Detail = postVM.Detail;
            postDB.Image = postVM.Image;
            postDB.HomeFlag = postVM.HomeFlag;
            postDB.HotFlag = postVM.HotFlag;
            postDB.IDCategory = postVM.IDCategory;
            postDB.ViewCount = postVM.ViewCount;
            postDB.Tags = postVM.Tags;

            //System Log
            postDB.CreateBy = postVM.CreateBy;
            postDB.CreateDate = postVM.CreateDate;
            postDB.MetaDescriptions = postVM.MetaDescriptions;
            postDB.MetaKeyWord = postVM.MetaKeyWord;
            postDB.MetaTitle = postVM.MetaTitle;
            postDB.UpdateBy = postVM.UpdateBy;
            postDB.UpdateDate = postVM.UpdateDate;
            postDB.Status = postVM.Status;
        }

        #endregion PostCate and Post

        #region ProductCate and Product

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCateVM)
        {
            productCategory.ID = productCateVM.ID;
            productCategory.Name = productCateVM.Name;
            productCategory.Description = productCateVM.Description;
            productCategory.Alias = productCateVM.Alias;
            productCategory.DisplayOder = productCateVM.DisplayOder;
            productCategory.HomeFlag = productCateVM.HomeFlag;
            productCategory.IdParent = productCateVM.IdParent;
            productCategory.Image = productCateVM.Image;

            //System Log
            productCategory.CreateBy = productCateVM.CreateBy;
            productCategory.CreateDate = productCateVM.CreateDate;
            productCategory.MetaDescriptions = productCateVM.MetaDescriptions;
            productCategory.MetaKeyWord = productCateVM.MetaKeyWord;
            productCategory.MetaTitle = productCateVM.MetaTitle;
            productCategory.UpdateBy = productCateVM.UpdateBy;
            productCategory.UpdateDate = productCateVM.UpdateDate;
            productCategory.Status = productCateVM.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productVM)
        {
            product.ID = productVM.ID;
            product.Name = productVM.Name;
            product.Alias = productVM.Alias;
            product.IDCategory = productVM.IDCategory;
            product.Image = productVM.Image;
            product.MoreImage = productVM.MoreImage;
            product.IncludeTaxes = productVM.IncludeTaxes;
            product.Price = productVM.Price;
            product.PromotionPrice = productVM.PromotionPrice;
            product.Description = productVM.Description;
            product.Warrnary = productVM.Warrnary;
            product.Detail = productVM.Detail;
            product.HomeFlag = productVM.HomeFlag;
            product.HotFlag = productVM.HotFlag;
            product.Tags = productVM.Tags;
            product.ViewCount = productVM.ViewCount;

            //System Log
            product.CreateBy = productVM.CreateBy;
            product.CreateDate = productVM.CreateDate;
            product.MetaDescriptions = productVM.MetaDescriptions;
            product.MetaKeyWord = productVM.MetaKeyWord;
            product.MetaTitle = productVM.MetaTitle;
            product.UpdateBy = productVM.UpdateBy;
            product.UpdateDate = productVM.UpdateDate;
            product.Status = productVM.Status;
        }

        #endregion ProductCate and Product

        #region Menu and MenuGroup

        public static void UpdateMenuGroup(this MenuGroup menuGroup, MenuGroupViewModel menuGroupVM)
        {
            menuGroup.ID = menuGroupVM.ID;
            menuGroup.Name = menuGroupVM.Name;
            menuGroup.Status = menuGroupVM.Status;
        }

        public static void UpdateMenu(this Menu menu, MenuViewModel menuVM)
        {
            menu.ID = menuVM.ID;
            menu.Name = menuVM.Name;
            menu.Url = menuVM.Url;
            menu.Target = menuVM.Target;
            menu.DisplayOder = menuVM.DisplayOder;
            menu.IDGroup = menuVM.IDGroup;
            menu.Status = menuVM.Status;
        }

        #endregion Menu and MenuGroup
    }
}