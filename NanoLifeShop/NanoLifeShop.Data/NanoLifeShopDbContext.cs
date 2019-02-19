using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NanoLifeShop.Models.Entity;

namespace NanoLifeShop.Data
{
    public class NanoLifeShopDBContext : IdentityDbContext<ApplicationUser>
    {
        public NanoLifeShopDBContext() : base("NanoLifeShopConnectString")
        {
            //Dont load child table 
            this.Configuration.LazyLoadingEnabled = false;
        }

        DbSet<Error> Errors { get; set; }
        DbSet<Footer> Footers { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<MenuGroup> MenuGroups { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostCategory> PostCategories { get; set; }
        DbSet<PostTag> PostTags { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<ProductTag> ProductTags { get; set; }
        DbSet<Slide> Slides { get; set; }
        DbSet<SupportOnline> SupportOnlines { get; set; }
        DbSet<SystemConfig> SystemConfigs { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        public static NanoLifeShopDBContext Create()
        {
            return new NanoLifeShopDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

            builder.Entity<IdentityUserRole>().HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserLogin>().HasKey(x => x.UserId);
        }
    }
}
