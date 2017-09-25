using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Notariat
{
    public class PersonDatabase
    {
        public static int ActionRowID { get; set; }
        public static SqlConnection myConnection = DBConnection.MyConnection;
        private static List<Person> _persons = null;
        public static List<Person> Persons
        {
            get
            {
                if (_persons == null)
                    _persons = new List<Person>();

                _persons.Clear();

                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                    myConnection.Open();

                SqlCommand command = new SqlCommand("GET_PERSON", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ActionRowId", ActionRowID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Person temp = new Person();
                        temp.ID = reader.GetInt64(0);
                        temp.Type = reader.GetString(1);
                        temp.Name = reader.GetString(2);
                        temp.UniqueCode = reader.GetString(3);
                        temp.IDCardSeries = reader.GetString(4);
                        temp.IDCardNumber = reader.GetString(5);
                        _persons.Add(temp); //Specify column index 
                    }
                }
                myConnection.Close();
                return _persons;
            }
        }


        public struct Person
        {
            public long ID { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string UniqueCode { get; set; }
            public string IDCardSeries { get; set; }
            public string IDCardNumber { get; set; }
        }
    }
}