using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager.Resources.Terraform;

namespace Pandora.Definitions.ResourceManager.Resources
{
    public class Service : ServiceDefinition
    {
        public string Name => "resources";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.Resources";
        
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>
        {
            new ResourceGroupDataSource(),
            new ResourceGroupResource(),
        };

        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new v2018_05_01.Resources(),
        };
    }
}