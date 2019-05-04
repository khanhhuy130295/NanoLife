using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.EquivalencyExpression;
using NanoLifeShop.Data;
using NanoLifeShop.Models.Entity;
using NanoLifeShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NanoLifeShop.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddCollectionMappers();
                cfg.SetGeneratePropertyMaps<GenerateEntityFrameworkPrimaryKeyPropertyMaps<NanoLifeShopDBContext>>();
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<MenuGroup, MenuGroupViewModel>();
                cfg.CreateMap<Menu, MenuViewModel>();
                cfg.CreateMap<SupportOnline, SupportOnlineViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderDetail, OrderDetailViewModel>();
                cfg.CreateMap<Slide, SlideViewModel>();
                cfg.CreateMap<PaymentMethod, PaymentMethodViewModel>();
            });
        }
    }
}