using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class DisasterRecoveryConfigsListAuthorizationRulesOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new DisasterRecoveryConfigId();
        }

        public override object NestedItemType()
        {
            return new AuthorizationRuleModel();
        }

        public override string? UriSuffix()
        {
            return "/authorizationRules";
        }


    }
}
