using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class UsersAndRoleViewModel
    {
        public List<ApplicationUser> allUser { get; set; }
        public List<IdentityRole> allRole { get; set; }

    }
}