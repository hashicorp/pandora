using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesDisasterRecoveryConfigs;

internal class DisasterRecoveryConfigsListAuthorizationRulesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new DisasterRecoveryConfigId();

    public override Type NestedItemType() => typeof(AuthorizationRuleModel);

    public override string? UriSuffix() => "/authorizationRules";


}
