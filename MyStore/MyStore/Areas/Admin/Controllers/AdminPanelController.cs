using Microsoft.AspNet.Identity.EntityFramework;
using MyStore.Entity;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyStore.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminPanelController : Controller
    {
        private ApplicationDbContext _context;
        private readonly ApplicationUserManager adminUsermanager;
        public AdminPanelController()
        {
            _context = new ApplicationDbContext();

            adminUsermanager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            _context.MyCategorys.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Admin/AdminPanel
        public ActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public ActionResult CreateRole()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(Role newRole)
        {
            _context.Roles.Add(new IdentityRole { Name = newRole.Name });
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditUserRole()
        {
            var allUser = _context.Users.ToList();
            var allRoles = _context.Roles.ToList();
            var allUseraNdRole = new UsersAndRoleViewModel
            { allRole = allRoles, allUser = allUser };
            return View(allUseraNdRole);
        }
        [HttpPost]
        public async Task<ActionResult> EditUserRole(string userName,string role)
        {
            var newRole = _context.Roles.First(x => x.Name == role);
          var currentUser=  _context.Users.First(x => x.UserName == userName);
            var currentRole = _context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == currentUser.Id).RoleId;
            //var currentUser = _context.Users.Where(x => x.UserName == model.allUser[0].UserName);
            await adminUsermanager.RemoveFromRoleAsync(currentUser.Id, currentRole);
            await adminUsermanager.AddToRoleAsync(currentUser.Id, newRole.Name);
            //_context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == currentUser.Id).RoleId = newRole.Id;
            _context.SaveChanges();
            
            return RedirectToAction("Index");

        }
        public ActionResult Admin()
        {

           


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

            return RedirectToAction("Index");
        }
    }
}