using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ActionGroupsAPIs.Definition(),
        new DataCollectionEndpoints.Definition(),
        new DataCollectionRuleAssociations.Definition(),
        new DataCollectionRules.Definition(),
    };
}
