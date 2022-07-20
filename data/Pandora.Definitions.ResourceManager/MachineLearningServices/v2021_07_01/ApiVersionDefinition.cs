using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new MachineLearningComputes.Definition(),
        new OperationalizationClusters.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Quota.Definition(),
        new VirtualMachineSizes.Definition(),
        new WorkspaceConnections.Definition(),
        new WorkspacePrivateEndpointConnections.Definition(),
        new WorkspacePrivateLinkResources.Definition(),
        new WorkspaceSkus.Definition(),
        new Workspaces.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
