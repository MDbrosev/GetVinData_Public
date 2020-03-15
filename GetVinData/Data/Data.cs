using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVinData.Data
{
    public class Data
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
}
