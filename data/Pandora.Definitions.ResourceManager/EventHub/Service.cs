using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub
{
    public class Service : ServiceDefinition
    {
        public string Name => "EventHub";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.EventHub";
        
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();

        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new v2017_04_01.Definition(),
            new v2018_01_01_preview.Definition(),
        };
    }
}