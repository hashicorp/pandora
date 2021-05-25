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
    }
}