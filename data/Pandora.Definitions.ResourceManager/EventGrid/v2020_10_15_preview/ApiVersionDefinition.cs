using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2020-10-15-preview";
        public bool Preview => true;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new DomainTopics.Definition(),
            new Domains.Definition(),
            new EventChannels.Definition(),
            new EventSubscriptions.Definition(),
            new PartnerNamespaces.Definition(),
            new PartnerRegistrations.Definition(),
            new PartnerTopics.Definition(),
            new PrivateEndpointConnections.Definition(),
            new PrivateLinkResources.Definition(),
            new SystemTopics.Definition(),
            new TopicTypes.Definition(),
            new Topics.Definition(),
        };
    }
}
