using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AggregatedAlert.Definition(),
        new AggregatedRecommendation.Definition(),
        new DeviceSecurityGroups.Definition(),
        new IoTSecurityAlertTypes.Definition(),
        new IoTSecurityAlerts.Definition(),
        new IoTSecurityRecommendationTypes.Definition(),
        new IoTSecurityRecommendations.Definition(),
        new IoTSecuritySolution.Definition(),
        new IoTSecuritySolutionAnalytics.Definition(),
    };
}
