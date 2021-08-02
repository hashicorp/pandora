using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d2183715d380084ff04313a73c8803d042fe91b9" 

        public string ApiVersion => "2017-04-01";
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
}
