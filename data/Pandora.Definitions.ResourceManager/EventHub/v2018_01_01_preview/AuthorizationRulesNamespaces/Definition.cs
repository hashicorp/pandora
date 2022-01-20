using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesNamespaces;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationRulesNamespaces";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NamespacesCreateOrUpdateAuthorizationRuleOperation(),
        new NamespacesDeleteAuthorizationRuleOperation(),
        new NamespacesGetAuthorizationRuleOperation(),
        new NamespacesListAuthorizationRulesOperation(),
        new NamespacesListKeysOperation(),
        new NamespacesRegenerateKeysOperation(),
    };
}
