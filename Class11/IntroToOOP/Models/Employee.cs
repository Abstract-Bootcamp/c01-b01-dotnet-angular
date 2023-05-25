using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroToOOP.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // protected int Id { get; set; }
        // protected string Name { get; set; }


        public string GetName()
        {
            return Name;
        }

        public string GetName(int id)
        {
            return Name;
        }

        public string GetName(string name)
        {
            return Name;
        }

        public string GetName(int id, string name)
        {
            return Name;
        }

        public string GetName(string name, int id)
        {
            return Name;
        }
        // public string Name { get; private set; }

        // public Employee(string name)
        // {
        //     Name = name;y
        // }
        // private int testId;
        // public int TestId
        // {
        //     get { return testId; }
        //     set { testId = value; }
        // }


        //     private int testId;
        //     public int TestId
        //     {
        //         get
        //         {
        //             return testId + 1;
        //         }
        //         set
        //         {
        //             if (value < 0)
        //             {
        //                 testId = 0;
        //             }
        //             else
        //             {

        //                 testId = value;
        //             }
        //         }
        //     }
    }
}