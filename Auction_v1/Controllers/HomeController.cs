using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction_v1.Models;

namespace Auction_v1.Controllers
{
    public class HomeController : Controller
    {
        MyDatabaseEntities db = new MyDatabaseEntities();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View(db.tblProducts);
        }
    }
}