using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2020-08-20";
        public bool Preview => false;

        public IEnumerable<ResourceDefinition> Apis => new List<ResourceDefinition>
        {
            new CommunicationService.Definition(),
        };
    }
}
