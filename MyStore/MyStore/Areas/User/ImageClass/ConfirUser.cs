using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyStore.Areas.User.ImageClass
{
    public class ConfigUSer
    {

        public static string NewsImagePath
        {
            get { return ConfigurationManager.AppSettings["UsersImagePath"]; }
        }
        public static string Domain
        {
            get { return ConfigurationManager.AppSettings["DomainProject"]; }
        }
    }
}