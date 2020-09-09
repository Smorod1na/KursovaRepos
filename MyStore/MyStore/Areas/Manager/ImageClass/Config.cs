using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyStore.Areas.Manager.ImageClass
{
    public class Config
    {
        
        public static string NewsImagePath
        {
            get { return ConfigurationManager.AppSettings["NewsImagePath"]; }
        }
        public static string Domain
        {
            get { return ConfigurationManager.AppSettings["DomainProject"]; }
        }
    }
}