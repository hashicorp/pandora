using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.Rules;

internal class Definition : ResourceDefinition
{
    public string Name => "Rules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TagRulesCreateOrUpdateOperation(),
        new TagRulesDeleteOperation(),
        new TagRulesGetOperation(),
        new TagRulesListOperation(),
    };
}
