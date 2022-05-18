using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Lab5
{
    public class Amount
    {
        [JsonProperty("result")]
        public double result { get; set; }
       

    }
}
