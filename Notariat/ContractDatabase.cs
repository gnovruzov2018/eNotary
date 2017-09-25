using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Notariat
{
    public class ContractDatabase
    {
        private static SqlConnection myConnection = DBConnection.MyConnection;
        private static List<Contract> _contracts = null;
        public static List<Contract> Contracts
        {
            get
            {
                if (_contracts == null)
                    _contracts = new List<Contract>();

                _contracts.Clear();

                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                    myConnection.Open();

                string office_code = HttpContext.Current.Request.QueryString["oc"];
                SqlCommand command = new SqlCommand("GET_BY_OFFICE_CODE", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Office_Code", int.Parse(office_code));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contract temp = new Contract();
                        temp.Status = reader.GetByte(0);
                        temp.StatusName = reader.GetString(1);
                        temp.TrackingCode = reader.GetString(2);
                        temp.NotaryOfficeName = reader.GetString(3);
                        temp.UpdateDate = Convert.ToString(reader.GetDateTime(4));
                        temp.ActionRowId = reader.GetInt64(5);
                        _contracts.Add(temp); //Specify column index 
                    }
                }
                myConnection.Close();
                return _contracts;
            }
        }

        public struct Contract
        {
            public byte Status { get; set; }
            public string StatusName { get; set; }
            public string TrackingCode { get; set; }
            public string NotaryOfficeName { get; set; }
            public string UpdateDate { get; set; }
            public long ActionRowId { get; set; }
        }

    }
}