using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration
{
    public class Service : ServiceDefinition
    {
        public string Name => "AppConfiguration";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.AppConfiguration";
        
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();

        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new v2019_10_01.Definition(),
            new v2020_06_01.Definition()
        };
    }
}