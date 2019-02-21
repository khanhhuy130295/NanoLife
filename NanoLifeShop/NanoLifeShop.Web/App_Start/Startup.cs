﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using NanoLifeShop.Data.Infastructures;
using Owin;
using NanoLifeShop.Data;
using NanoLifeShop.Data.Repositories;
using NanoLifeShop.Service;
using System.Web.Mvc;
using System.Web.Http;

[assembly: OwinStartup(typeof(NanoLifeShop.Web.App_Start.Startup))]

namespace NanoLifeShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutoFac(app);

        }

        public void ConfigAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var dataAccess = Assembly.GetExecutingAssembly();

            //Register Controller and Api Controller
            builder.RegisterControllers(dataAccess);
            builder.RegisterApiControllers(dataAccess);



            //Register DBcontext, UnitOfWork, Dbfactory

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DBFactory>().As<IDBFactory>().InstancePerRequest();
            builder.RegisterType<NanoLifeShopDBContext>().AsSelf().InstancePerRequest();


            //Regiter Repository
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //Regiter Service
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

            Autofac.IContainer container = builder.Build();

            //Set Controller dependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Set the Web Api dependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
