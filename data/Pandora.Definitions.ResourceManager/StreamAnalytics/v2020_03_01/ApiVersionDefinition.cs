using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Clusters.Definition(),
        new Functions.Definition(),
        new Inputs.Definition(),
        new Outputs.Definition(),
        new PrivateEndpoints.Definition(),
        new StreamingJobs.Definition(),
        new Subscriptions.Definition(),
        new Transformations.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
