using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BatchDeployment.Definition(),
        new BatchEndpoint.Definition(),
        new CodeContainer.Definition(),
        new CodeVersion.Definition(),
        new ComponentContainer.Definition(),
        new ComponentVersion.Definition(),
        new DataContainer.Definition(),
        new DataVersion.Definition(),
        new Datastore.Definition(),
        new EnvironmentContainer.Definition(),
        new EnvironmentVersion.Definition(),
        new Job.Definition(),
        new MachineLearningComputes.Definition(),
        new ModelContainer.Definition(),
        new ModelVersion.Definition(),
        new OnlineDeployment.Definition(),
        new OnlineEndpoint.Definition(),
        new OperationalizationClusters.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Quota.Definition(),
        new V2WorkspaceConnectionResource.Definition(),
        new VirtualMachineSizes.Definition(),
        new WorkspacePrivateEndpointConnections.Definition(),
        new WorkspacePrivateLinkResources.Definition(),
        new Workspaces.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
