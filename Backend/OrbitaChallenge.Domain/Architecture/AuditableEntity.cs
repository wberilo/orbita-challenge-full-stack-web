using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Domain.Architecture
{
    public abstract class AuditableEntity
    {
        public DateTime CreationDate { get; }
        public DateTime? LastUpdateDate { get; }
    }
}
