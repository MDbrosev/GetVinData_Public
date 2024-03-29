﻿using System.Collections.Generic;
using System.Data.SqlClient;


namespace GetVinData.DB_Connection
{
    class DB_Connection
    {
        public List<string> GetVINs()
        {
            var con = @"";
                //ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();

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
