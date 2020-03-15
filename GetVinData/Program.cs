using Newtonsoft.Json;
using System;
using System.Net.Http;
using static GetVinData.Data.Data;

namespace GetVinData
{
    public class Program
    {
        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        VehicleData vehicledata = JsonConvert.DeserializeObject<VehicleData>(mycontent);

                        string oldVIN = vehicledata.SearchCriteria;
                        ParseVIN(oldVIN);
                        ParseTrim(vehicledata);
                    }
                }
            }
        }

        public static void ParseVIN(string oldVIN)
        {
            string newString = oldVIN.Remove(0, 4);
            Console.WriteLine(newString);
        }

        public static void ParseTrim(VehicleData vehicledata)
        {
            if (vehicledata == null)
            {
                throw new ArgumentNullException(nameof(vehicledata));
            }

            foreach (var v in vehicledata.Results)
            {
                if (v.VariableId.Equals(26))
                {
                    if (v.Value.ToUpper().Equals("BUICK") || v.Value.ToUpper().Equals("CADILLAC")
                        || v.Value.ToUpper().Equals("CHEVROLET") || v.Value.ToUpper().Equals("CHRYSLER")
                        || v.Value.ToUpper().Equals("DODGE") || v.Value.ToUpper().Equals("GENESIS")
                        || v.Value.ToUpper().Equals("GMC") || v.Value.ToUpper().Equals("HYUNDAI")
                        || v.Value.ToUpper().Equals("JEEP") || v.Value.ToUpper().Equals("RAM")
                        || v.Value.ToUpper().Equals("VOLKSWAGEN"))
                    {
                        foreach (var v2 in vehicledata.Results)
                        {
                            if (v2.VariableId.Equals(34))
                            {
                                Console.WriteLine(v2.Value);
                            }
                        }
                    }
                    else if (v.Value.ToUpper().Equals("MAZDA"))
                    {
                        foreach (var v2 in vehicledata.Results)
                        {
                            if (v2.VariableId.Equals(15))
                            {
                                Console.WriteLine(v2.Value);
                            }
                        }
                    }
                    else if (v.Value.ToUpper().Equals("MITSUBISHI"))
                    {
                        foreach (var v2 in vehicledata.Results)
                        {
                            if (v2.VariableId.Equals(34))
                            {
                                if (v2.Value.ToUpper().Equals("PREMIUM"))
                                {
                                    Console.WriteLine("SE");
                                }
                                else if (v2.Value.ToUpper().Equals("HIGH"))
                                {
                                    Console.WriteLine("LE");
                                }
                                else if (v2.Value.ToUpper().Equals("MEDIUM"))
                                {
                                    Console.WriteLine("ES");
                                }
                            }
                        }
                    }
                    else if (v.Value.ToUpper().Equals("NISSAN") || v.Value.ToUpper().Equals("SUBARU")
                        || v.Value.ToUpper().Equals("TOYOTA"))
                    {
                        foreach (var v3 in vehicledata.Results)
                        {
                            if (v3.VariableId.Equals(38))
                            {
                                Console.WriteLine(v3.Value);
                            }
                        }
                    }
                }
            }
        }

        //TODO: method to pull all of the vins for new + on order + sold cars

        //TODO: method to insert the new vins with trims to database

        static void Main(string[] args)
        {
            string vin = "";

            //Change the link to decode batch
            GetRequest("https://vpic.nhtsa.dot.gov/api/vehicles/decodevin/" + vin + "?format=json");
            Console.ReadKey();
        }
    }
}