using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcPartsManager.Models;

public interface IEntity { }

public interface IAuditedEntity : IEntity
{
    DateTime CreatedOn { get; set; }
    DateTime ModifiedOn { get; set; }
}

public class AuditedEntity : IAuditedEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
