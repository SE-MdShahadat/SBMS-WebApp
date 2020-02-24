using AutoMapper;
using SBMSwebApp.Models;
using SBMSwebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SBMSwebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(config: cfg =>
            {
                cfg.CreateMap<SupplierVM, Supplier>();
                cfg.CreateMap<Supplier, SupplierVM>();

            });
        }
    }
}
