using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCars.Models
{
    public class Cars
    {
        public int AutomobileID { get; set; }
        public int CompanyID { get; set; }
        public string Status { get; set; }
        public int ModelID { get; set; }
        public double Price { get; set; }

        // getting Company Name from Companies Table
        public string Name { get; set; }

        // getting Columns from Model Details Table
        public int ModelNumber { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
    }
}