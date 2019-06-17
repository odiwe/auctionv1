using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction_v1.Models;
using System.Net;

namespace Auction_v1.Controllers
{
    public class ProductController : Controller
    {
        MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewProduct()
        {
            return View();
        }

        
        public ActionResult SaveData(tblProduct item)
        {
            if (item.ProductName != null && item.ProductCategory != null && item.ProductPrice != null &&
                item.ProductClose != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.ImageUpload.FileName);
                string extension = Path.GetExtension(item.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.PicUrl = fileName;
                item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Uploads/Products"), fileName));
                db.tblProducts.Add(item);
                db.SaveChanges();
            }

            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct item = db.tblProducts.Find(id);
            //id = item.ProductID;
            return View(item);
        }

        public ActionResult Clothing()
        {
            MyDatabaseEntities cloth = new MyDatabaseEntities();
            var cloths = from cat in cloth.tblProducts where (cat.ProductCategory == "Clothing") select cat;

            
            return View(cloths);
        }

        public ActionResult Tech()
        {
            MyDatabaseEntities cloth = new MyDatabaseEntities();
            var cloths = from cat in cloth.tblProducts where (cat.ProductCategory == "Tech") select cat;


            return View(cloths);
        }

        public ActionResult Automobile()
        {
            MyDatabaseEntities cloth = new MyDatabaseEntities();
            var cloths = from cat in cloth.tblProducts where (cat.ProductCategory == "Automobile") select cat;


            return View(cloths);
        }

        public ActionResult Furniture()
        {
            MyDatabaseEntities cloth = new MyDatabaseEntities();
            var cloths = from cat in cloth.tblProducts where (cat.ProductCategory == "Furniture") select cat;


            return View(cloths);
        }
    }
}