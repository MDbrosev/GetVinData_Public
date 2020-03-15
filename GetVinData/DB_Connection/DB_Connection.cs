using GetVinData.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVinData.DB_Connection
{
    class DB_Connection
    {
        public List<string> GetVINs()
        {
            var con = @"";

            List<string> vin_numbers = new List<string>();

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select VIN from [DeveloperDB].[dbo].[Vehicle_VIN]";

                SqlCommand oCmd = new SqlCommand(oString, myConnection);                

                myConnection.Open();

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        vin_numbers.Add(oReader["VIN"].ToString());
                    }
                    
                    myConnection.Close();
                }
            }
            return vin_numbers;
        }
    }

    //TODO: method to insert the new vins with trims to database

}
