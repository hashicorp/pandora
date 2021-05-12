using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ServicesDefinition
    {
        IEnumerable<ServiceDefinition> Services { get; }
    }
}