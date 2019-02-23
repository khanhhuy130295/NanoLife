namespace NanoLifeShop.Data.Migrations
{
    using NanoLifeShop.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NanoLifeShop.Data.NanoLifeShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NanoLifeShop.Data.NanoLifeShopDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.PostCategories.Count() == 0)
            {
                List<PostCategory> listCate = new List<PostCategory>()
                {
                    new PostCategory(){Name = "Tin thế giới",Alias="Tin-the-gioi",Status = true, CreateDate = DateTime.Now},
                    new PostCategory(){Name = "Tin thế giới",Alias="Tin-the-gioi",Status = true, CreateDate = DateTime.Now},
                    new PostCategory(){Name = "Tin thế giới",Alias="Tin-the-gioi",Status = true, CreateDate = DateTime.Now},

                };
                context.PostCategories.AddRange(listCate);
                context.SaveChanges();

            }


        }
    }
}
