using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CognitiveServicesAccounts.Definition(),
        new CommitmentPlans.Definition(),
        new CommitmentTiers.Definition(),
        new Deployments.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Skus.Definition(),
    };
}
