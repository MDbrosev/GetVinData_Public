﻿namespace GetVinData.Data
{
    public class NHTSA_API_Data
    {
        public class VehicleData
        {
            public int Count { get; set; }
            public string Message { get; set; }
            public string SearchCriteria { get; set; }
            public Result[] Results { get; set; }
        }

        public class Result
        {
            public string Value { get; set; }
            public string ValueId { get; set; }
            public string Variable { get; set; }
            public int VariableId { get; set; }
        }
    }

    public class VINs_To_Query
    {
        public string Vin { get; set; }        
    }
}
