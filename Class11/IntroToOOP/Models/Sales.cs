using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroToOOP.Models
{
    public class Sales : Employee
    {
        public decimal Commission { get; set; }
        public decimal GetCommission()
        {
            var a = Name;
            return 1;
        }
    }

    public class Developer : Employee
    {
    }

    public class Accountant : Employee
    {
    }
}