using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckPolicyRestrictions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PolicyRestrictionsCheckAtManagementGroupScopeOperation(),
        new PolicyRestrictionsCheckAtResourceGroupScopeOperation(),
        new PolicyRestrictionsCheckAtSubscriptionScopeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FieldRestrictionResultConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckManagementGroupRestrictionsRequestModel),
        typeof(CheckRestrictionEvaluationDetailsModel),
        typeof(CheckRestrictionsRequestModel),
        typeof(CheckRestrictionsResourceDetailsModel),
        typeof(CheckRestrictionsResultModel),
        typeof(CheckRestrictionsResultContentEvaluationResultModel),
        typeof(ExpressionEvaluationDetailsModel),
        typeof(FieldRestrictionModel),
        typeof(FieldRestrictionsModel),
        typeof(IfNotExistsEvaluationDetailsModel),
        typeof(PendingFieldModel),
        typeof(PolicyEffectDetailsModel),
        typeof(PolicyEvaluationResultModel),
        typeof(PolicyReferenceModel),
    };
}
