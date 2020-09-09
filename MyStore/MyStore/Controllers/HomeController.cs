using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //if (userId != null)
            //{
            //    var RoleId = _context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == userId).RoleId;

            //    var role = _context.Roles.FirstOrDefault(x => x.Id == RoleId);

            //    if (role.Name == "Admin")
            //        return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });

            //}
            return View();

        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Test(string name,string isAdmine)
        {


            return RedirectToAction("Admin");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Admin()
        {

            var allUser = _context.Users.ToList();
            var allRoles = _context.Roles.ToList();
            var allUseraNdRole = new UsersAndRoleViewModel 
                            { allRole = allRoles, allUser = allUser };


            //var adminID = _context.Roles.FirstOrDefault(x => x.Name == "Admin").Id;
            //var MyUsers = new List<AllUser>();
            //foreach (var item in allUser)
            //{
            //    var statusRole = _context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == item.Id && x.RoleId == adminID);
            //    if (statusRole != null)
            //    {
            //        MyUsers.Add(new AllUser
            //        {
            //            Email = item.UserName,
            //            IsAdmin = true
            //        });
            //    }
            //    else
            //    {
            //        MyUsers.Add(new AllUser
            //        {
            //            Email = item.UserName,
            //            IsAdmin = false
            //        });
            //    }
            //}

            return RedirectToAction("Index","Admin");
        }
    }
}