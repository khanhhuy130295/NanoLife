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
            product.OriginalPrice = productVM.OriginalPrice;        
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

        #region SupportOnline

        public static void UpdateSupportOnline(this SupportOnline supportOnline, SupportOnlineViewModel supportOnlineVM)
        {
            supportOnline.ID = supportOnlineVM.ID;
            supportOnline.Name = supportOnlineVM.Name;
            supportOnline.Department = supportOnlineVM.Department;
            supportOnline.Address = supportOnlineVM.Address;
            supportOnline.Email = supportOnlineVM.Email;
            supportOnline.Skype = supportOnlineVM.Skype;
            supportOnline.Facebook = supportOnlineVM.Facebook;
            supportOnline.Mobile = supportOnlineVM.Mobile;
            supportOnline.Lng = supportOnlineVM.Lng;
            supportOnline.Lat = supportOnlineVM.Lat;
            supportOnline.DisplayOder = supportOnlineVM.DisplayOder;
            supportOnline.Status = supportOnlineVM.Status;
        }

        #endregion SupportOnline

        #region Order and OrderDetail and PaymentMethod

        public static void UpdateOrder(this Order order, OrderViewModel orderVM)
        {
            order.ID = orderVM.ID;
            order.CreateBy = orderVM.CreateBy;
            order.CreateDate = orderVM.CreateDate;
            order.CustomerAddress = orderVM.CustomerAddress;
            order.CustomerEmail = orderVM.CustomerEmail;
            order.CustomerMessages = orderVM.CustomerMessages;
            order.CustomerName = orderVM.CustomerName;
            order.CustomerPhone = orderVM.CustomerPhone;
            order.ID_PaymentMethod = orderVM.ID_PaymentMethod;
            order.PaymentStatus = orderVM.PaymentStatus;
            order.Status = orderVM.Status;
        }

        public static void UpdateOrderDetail(this OrderDetail orderDetail, OrderDetailViewModel orderDetailViewModel)
        {
            orderDetail.ID_Order = orderDetailViewModel.ID_Order;
            orderDetail.ID_Product = orderDetailViewModel.ID_Product;
            orderDetail.Price = orderDetailViewModel.ID_Product;
            orderDetail.Quantity = orderDetailViewModel.Quantity;
            orderDetail.TotalPrice = orderDetailViewModel.TotalPrice;
        }

        public static void UpdatePaymentMethod(this PaymentMethod paymentMethod, PaymentMethodViewModel paymentMethodVM)
        {
            paymentMethod.ID_PaymentMethod = paymentMethodVM.ID_PaymentMethod;
            paymentMethod.DisplayName = paymentMethodVM.DisplayName;
            paymentMethod.Status = paymentMethodVM.Status;     
        }

        #endregion Order and OrderDetail

        #region FeedBack

        public static void UpdateFeedBack(this FeedBack feedBack, FeedBackViewModel feedBackVM)
        {
            feedBack.ID = feedBackVM.ID;
            feedBack.Messages = feedBackVM.Messages;
            feedBack.CreateDate = feedBackVM.CreateDate;
            feedBack.Email = feedBackVM.Email;
            feedBack.Name = feedBackVM.Name;
            feedBack.Phone = feedBackVM.Phone;
            feedBack.Status = feedBackVM.Status;
        }

        #endregion FeedBack

        #region Slide
        public static void UpdateSlide(this Slide slide, SlideViewModel slideVM)
        {
            slide.ID = slideVM.ID;
            slide.Name = slideVM.Name;
            slide.Status = slideVM.Status;
            slide.Url = slideVM.Url;
            slide.Content = slideVM.Content;
            slide.Description = slideVM.Description;
            slide.DisplayOder = slideVM.DisplayOder;
        }

        #endregion Slide
    }
}