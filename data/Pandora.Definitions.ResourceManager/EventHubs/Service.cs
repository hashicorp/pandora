using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHubs
{
    public class Service : Interfaces.ServiceDefinition
    {
        public string Name => "eventhubs";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.EventHub";
        
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();

        public IEnumerable<ApiVersionDefinition> Versions => new List<ApiVersionDefinition>
        {
            new v2018_01_01_preview.Definition(),
        };
    }
}