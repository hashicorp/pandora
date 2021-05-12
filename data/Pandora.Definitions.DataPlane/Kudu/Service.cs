using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.Kudu
{
    public class Service : ServiceDefinition
    {
        public string Name => "kudu";
        public bool Generate => true;
        public string? ResourceProvider => null;
        
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();

        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new Unversioned.Definition()
        };
    }
}