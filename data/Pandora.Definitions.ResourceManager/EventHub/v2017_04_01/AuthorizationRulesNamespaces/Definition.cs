using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2017-04-01";
        public string Name => "AuthorizationRulesNamespaces";
        public IEnumerable<ApiOperation> Operations => new List<ApiOperation>
        {
            new NamespacesCreateOrUpdateAuthorizationRule(),
            new NamespacesDeleteAuthorizationRule(),
            new NamespacesGetAuthorizationRule(),
            new NamespacesListAuthorizationRules(),
            new NamespacesListKeys(),
            new NamespacesRegenerateKeys(),
        };
    }
}