using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using Dominio;
using System.Net.Http.Formatting;

namespace ClienteWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
    }
}