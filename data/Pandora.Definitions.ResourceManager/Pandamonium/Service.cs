using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Pandamonium
{
    public class Service : ServiceDefinition
    {
        public string Name => "Pandamonium";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.Blah";
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new v2020_01_01.Definition()
        };
    }
}