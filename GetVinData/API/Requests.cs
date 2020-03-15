using GetVinData.Parser;
using Newtonsoft.Json;
using System.Net.Http;

using static GetVinData.Data.NHTSA_API_Data;

namespace GetVinData.API
{
    class Requests
    {
        public async static void GetRequest(string url)
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
                        Parsers.ParseVIN(oldVIN);
                        Parsers.ParseTrim(vehicledata);
                    }
                }
            }
        }
    }
}
