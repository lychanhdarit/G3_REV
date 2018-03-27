using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3_REV.Data
{
    class BaseServ
    {
        protected static string dbConnString;
       
        public BaseServ()
        {
            dbConnString = ConfigurationManager.AppSettings["connectionString"].ToString();
        }
    }
}
