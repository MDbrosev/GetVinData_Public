using System;
using static GetVinData.Data.NHTSA_API_Data;

namespace GetVinData.Parser
{
    class Parsers
    {
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
    }
}
