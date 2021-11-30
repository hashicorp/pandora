using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-10-15-preview";
        public string Name => "TopicTypes";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new ListOperation(),
            new ListEventTypesOperation(),
        };
    }
}
