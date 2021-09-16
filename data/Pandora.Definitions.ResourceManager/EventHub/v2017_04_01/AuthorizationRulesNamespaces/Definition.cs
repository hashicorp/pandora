using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "70de88e5fb00b9217a5cafd3c1bed11ce311fc52" 

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
