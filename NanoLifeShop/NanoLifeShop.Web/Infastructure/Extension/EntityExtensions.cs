using NanoLifeShop.Models.Entity;
using NanoLifeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Infastructure.Extension
{
    public static class EntityExtensions
    {
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

        public static void UpdatePost (this Post postDB, PostViewModel postVM)
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


    }
}