using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsManager.ViewModels
{
    public class Pagination<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}