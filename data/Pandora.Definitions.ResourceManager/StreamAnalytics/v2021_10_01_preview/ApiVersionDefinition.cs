using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-10-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Functions.Definition(),
        new Inputs.Definition(),
        new Outputs.Definition(),
        new StreamingJobs.Definition(),
        new Subscriptions.Definition(),
        new Transformations.Definition(),
    };
}
