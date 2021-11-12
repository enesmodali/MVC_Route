using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Route
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          


            // Urunler/Detaylar/{CategoryName}/{CategoryID}/{ProductName}/{ProductID}
            // ÖR: Urunler/Detaylar/Beverages/1/Chai/1 şeklinde bir URL yapısı görünecektir.    
            routes.MapRoute(
                name:"UrunRoute",
                url:"Urunler/Detaylar/{CategoryName}/{CategoryID}/{ProductName}/{ProductID}",
                defaults: new 
                {
                controller= "Product",
                action="Details",
                CategoryName=UrlParameter.Optional,
                CategoryID=UrlParameter.Optional,
                ProductName=UrlParameter.Optional,
                ProductID=UrlParameter.Optional
                }
                );

            //Örnek: hepsiburada.com/UrunAdi-p-StokKodu
            //Details için: 
            //ProductName: Chai
            //ProductID: 1
            routes.MapRoute(
                name:"UrunDetayRoute",
                url:"{ProductName}-p-{ProductID}",
                defaults: new 
                {
                controller = "Product",
                action= "Details",
                ProductName=UrlParameter.Optional,
                ProductID=UrlParameter.Optional

                }

                );





            //Default en altta kalacak. Çünkü yukarıdaki route lardan birini karşılayamazsa bunu kullanacak.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
