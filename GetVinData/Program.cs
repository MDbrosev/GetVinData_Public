using GetVinData.API;
using System;


namespace GetVinData
{
    public class Program
    {
        static void Main(string[] args)
        {            
            DB_Connection.DB_Connection db = new DB_Connection.DB_Connection();
            var vins = db.GetVINs();

            foreach (var vin in vins)
            {
                Requests.GetRequest("https://vpic.nhtsa.dot.gov/api/vehicles/decodevin/" + vin + "?format=json");
            }
            Console.ReadKey();
        }
    }
}