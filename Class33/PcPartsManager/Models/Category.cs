using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsManager.Models
{
    public class Category : AuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
