using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GAtec.Northwind.Util
{
    public static class NorthwindSettings
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString; }
        }

        public static string ApplicationName
        {
            get { return ConfigurationManager.AppSettings["ApplicationName"]; }
        }
    }
}
