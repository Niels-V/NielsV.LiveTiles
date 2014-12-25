using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace NielsV.LiveTiles.Routes
{
    public class LiveTilesRoutes : IRouteProvider
    {
         public void GetRoutes(ICollection<RouteDescriptor> routes) { 
             foreach (var routeDescriptor in GetRoutes()) 
                 routes.Add(routeDescriptor); 
         } 
 

         public IEnumerable<RouteDescriptor> GetRoutes() {
             return new[] {
                 new RouteDescriptor { 
                     Route = new Route( 
                         "browserconfig.xml", 
                         new RouteValueDictionary { 
                             {"area", "NielsV.LiveTiles"}, 
                             {"controller", "BrowserConfig"}, 
                             {"action", "Xml"} 
                         }, 
                         new RouteValueDictionary(), 
                         new RouteValueDictionary { 
                             {"area", "NielsV.LiveTiles"} 
                         }, 
                         new MvcRouteHandler()) 
                 } 
             }; 
         } 

    }
}