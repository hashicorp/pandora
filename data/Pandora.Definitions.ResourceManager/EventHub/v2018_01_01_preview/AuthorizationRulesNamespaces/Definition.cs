using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesNamespaces
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "v2018-01-01-preview";
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