using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.NetworkFunction.v2022_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AzureTrafficCollectors.Definition(),
        new CollectorPolicies.Definition(),
    };
}
