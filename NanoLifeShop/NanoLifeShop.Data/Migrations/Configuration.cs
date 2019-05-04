namespace NanoLifeShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            //Create Account
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NanoLifeShopDBContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NanoLifeShopDBContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "admin",
            //    Email = "khanhhuy130295@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Dương Hồng Khánh Huy"
            //};

            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });

            //}

            //var adminUser = manager.FindByEmail("khanhhuy130295@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });


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

            if (context.SupportOnlines.Count() == 0)
            {
                SupportOnline support = new SupportOnline()
                {
                    Address = "118/127C/3 Phan Huy Ích, P.15, Tân Bình, HCM.",
                    Mobile = "(028) 6684 0202",
                    Email = "support@gmail.com",
                    Facebook = "https://www.facebook.com/khanhhuy1302",
                    Department = "Kinh doanh",
                    Name = "CÔNG TY TNHH NGHIÊN CỨU SX & TM NANO LIFE"
                };

                context.SupportOnlines.Add(support);
                context.SaveChanges();
            }


            if (context.PaymentMethods.Count() == 0)
            {
                List<PaymentMethod> listPayMentMethod = new List<PaymentMethod>()
                {
                    new PaymentMethod(){ID_PaymentMethod = "COD",DisplayName="Đặt hàng Online"},
                    new PaymentMethod(){ID_PaymentMethod = "bank",DisplayName="Ngân Hàng"}
                };
                context.PaymentMethods.AddRange(listPayMentMethod);
                context.SaveChanges();
            }
        }
    }
}
