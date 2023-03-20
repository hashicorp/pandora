using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Monitors.Definition(),
        new ProviderInstances.Definition(),
        new SAPApplicationServerInstances.Definition(),
        new SAPAvailabilityZoneDetails.Definition(),
        new SAPCentralInstances.Definition(),
        new SAPDatabaseInstances.Definition(),
        new SAPDiskConfigurations.Definition(),
        new SAPRecommendations.Definition(),
        new SAPSupportedSku.Definition(),
        new SAPVirtualInstances.Definition(),
        new SapLandscapeMonitor.Definition(),
    };
}
