using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Account.Definition(),
        new DefaultAccount.Definition(),
        new Feature.Definition(),
        new KafkaConfiguration.Definition(),
        new PrivateEndpointConnection.Definition(),
        new PrivateLinkResource.Definition(),
        new Provider.Definition(),
        new Usages.Definition(),
    };
}
