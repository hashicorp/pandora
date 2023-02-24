using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Activityruns.Definition(),
        new Credentials.Definition(),
        new DataFlowDebugSession.Definition(),
        new DataFlows.Definition(),
        new Datasets.Definition(),
        new ExposureControl.Definition(),
        new Factories.Definition(),
        new GlobalParameters.Definition(),
        new IntegrationRuntimeNodes.Definition(),
        new IntegrationRuntimeObjectMetadata.Definition(),
        new IntegrationRuntimes.Definition(),
        new LinkedServices.Definition(),
        new ManagedPrivateEndpoints.Definition(),
        new ManagedVirtualNetworks.Definition(),
        new PipelineRuns.Definition(),
        new Pipelines.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Trigger.Definition(),
        new Triggerruns.Definition(),
        new Triggers.Definition(),
    };
}
