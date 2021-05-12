using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview
{
    public class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2018-01-01-preview";
        public bool Generate => true;
        public bool Preview => true;
        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new ConsumerGroup.Definition(),
            new EventHub.Definition(),
            new Namespace.Definition(),
        };
    }
}