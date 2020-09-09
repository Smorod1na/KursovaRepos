using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyStore.Areas.User.ImageClass;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MyStore.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: User/User
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var test = _context.Users.Find(userId);
            ViewBag.News = _context.MyNews.ToArray();
            return View(test);
        }

        [HttpGet]
        public ActionResult ChangeUser()
        {
            UserAditionalInfo changeUser = new UserAditionalInfo();


            var userId = User.Identity.GetUserId();
            var test = _context.Users.Find(userId);

            var testAdditional = _context.UsersAditionalInfo.FirstOrDefault(x => x.Id == userId) ;

            if(testAdditional!=null)
            return View(testAdditional);

            else
            {
                changeUser.ApplicationUser = test;
                return View(changeUser);
            }
        }
        [HttpPost]
        public ActionResult ChangeUser(UserAditionalInfo user, HttpPostedFileBase imageFile)
        {
            UserManager<ApplicationUser> compilchange = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            user.Image = CreateBitmap(imageFile);
            var currentAdUser = _context.UsersAditionalInfo.First(x => x.Id == user.Id);

            if (currentAdUser != user)
            {
                if (currentAdUser.ApplicationUser == user.ApplicationUser)
                    currentAdUser = user;
                else
                {
                    //var userId = User.Identity.GetUserId();

                    compilchange.SetEmail(user.Id, user.ApplicationUser.Email);

                    _context.UsersAditionalInfo.First(x => x.Id == user.Id).FullName = user.FullName;
                    _context.UsersAditionalInfo.First(x => x.Id == user.Id).Image = CreateBitmap(imageFile);

                    _context.SaveChanges();
                }
            }


            //_context.Set<UserAditionalInfo>().First(x => x == currentAddUser)=user;

            
            return RedirectToAction("Index");
        }
        public string CreateBitmap(HttpPostedFileBase imageFile)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPathImage = Server.MapPath(ConfigUSer.NewsImagePath) + "\\" + fileName;
            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                var readyImage = ImageWorkerUser.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(fullPathImage, ImageFormat.Jpeg);

                }
            }
            return fileName;
        }
        public ActionResult Home()
        {

            var userId = User.Identity.GetUserId();
            
            var currentUser= _context.UsersAditionalInfo.Find(userId);
            return View(currentUser);
        }
    }
}