using MyStore.Areas.Manager.ImageClass;
using MyStore.Entity;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyStore.Areas.Manager.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;
        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Manager/Manager
        public ActionResult Index()
        {
            string id =ConfigurationManager.AppSettings["ManagerId"].ToString();

            var managerNews = _context.MyNews.Where(x => x.ManagerId == id).ToList();

            return View(managerNews);
        }
        [HttpGet]
        public ActionResult CreateNews()
        {
            ViewBag.Categories = _context.MyCategorys.ToArray();
            return View();
        }
        public ActionResult Return()
        {
            return RedirectToAction("LogOff", "Account");
        }
        [HttpPost]
        public ActionResult CreateNews(News news, HttpPostedFileBase imageFile)
        {
            news.Pfoto = CreateBitmap(imageFile);
            news.ManagerId = ConfigurationManager.AppSettings["ManagerId"].ToString();
            news.PostDate = DateTime.Now;
            news.NewsCategory = _context.MyCategorys.Where(x => x.Name == news.Categorie).ToArray()[0];
            _context.MyNews.Add(news);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Index", "Home");
        //}
        public string CreateBitmap(HttpPostedFileBase imageFile)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPathImage = Server.MapPath(Config.NewsImagePath) + "\\" + fileName;
            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                var readyImage = ImageWorker.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(fullPathImage, ImageFormat.Jpeg);
                   
                }
            }
            return fileName;
        }
    }
}