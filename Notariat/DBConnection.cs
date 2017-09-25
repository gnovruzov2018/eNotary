using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Notariat
{
    public class DBConnection
    {
        private static SqlConnection myConnection = null;
        public static SqlConnection MyConnection
        { get
          {
            return new SqlConnection(@"Data Source=192.168.65.1;Initial Catalog=NOT_DB_CSDR;User ID=eNotariat_user;Password=Tarantello");
          }
        }
    }
}