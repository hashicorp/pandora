using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-02-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Keys.Definition(),
        new MHSMListPrivateEndpointConnections.Definition(),
        new MHSMListRegions.Definition(),
        new MHSMPrivateEndpointConnections.Definition(),
        new MHSMPrivateLinkResources.Definition(),
        new ManagedHsmKeys.Definition(),
        new ManagedHsms.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Secrets.Definition(),
        new Vaults.Definition(),
    };
}
