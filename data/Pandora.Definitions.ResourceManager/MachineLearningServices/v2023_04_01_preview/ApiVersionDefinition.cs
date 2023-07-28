using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01-preview";
    public bool Preview => true;
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
        new DataContainerRegistry.Definition(),
        new DataVersion.Definition(),
        new DataVersionRegistry.Definition(),
        new Datastore.Definition(),
        new EnvironmentContainer.Definition(),
        new EnvironmentVersion.Definition(),
        new Feature.Definition(),
        new FeaturesetContainer.Definition(),
        new FeaturesetVersion.Definition(),
        new FeaturestoreEntityContainer.Definition(),
        new FeaturestoreEntityVersion.Definition(),
        new Job.Definition(),
        new LabelingJob.Definition(),
        new MachineLearningComputes.Definition(),
        new ManagedNetwork.Definition(),
        new ModelContainer.Definition(),
        new ModelVersion.Definition(),
        new OnlineDeployment.Definition(),
        new OnlineEndpoint.Definition(),
        new OperationalizationClusters.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PrivateEndpointConnections.Definition(),
        new ProxyOperations.Definition(),
        new Quota.Definition(),
        new RegistryManagement.Definition(),
        new Schedule.Definition(),
        new V2WorkspaceConnectionResource.Definition(),
        new VirtualMachineSizes.Definition(),
        new WorkspacePrivateEndpointConnections.Definition(),
        new WorkspacePrivateLinkResources.Definition(),
        new Workspaces.Definition(),
    };
}
