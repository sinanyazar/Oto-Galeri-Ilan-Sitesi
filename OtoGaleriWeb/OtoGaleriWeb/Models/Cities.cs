using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace OtoGaleriWeb.Models
{
    public class Cities
    {
        public string City { get; set; }
        public string State { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }

        //------------------------------------------

        public override string ToString()
        {
            return this.City;
        }
    }
}