using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-05-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AutoscaleSettings.Definition(),
        new DiagnosticSettings.Definition(),
        new DiagnosticSettingsCategories.Definition(),
        new Insights.Definition(),
        new ManagementGroupDiagnosticSettings.Definition(),
        new Metrics.Definition(),
        new SubscriptionDiagnosticSettings.Definition(),
    };
}
