// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Policies.StableV1.PolicyFeatureRolloutPolicyAppliesTo;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyFeatureRolloutPolicyAppliesTo";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddPolicyFeatureRolloutPolicyByIdAppliesToRefOperation(),
        new CreatePolicyFeatureRolloutPolicyByIdAppliesToOperation(),
        new GetPolicyFeatureRolloutPolicyByIdAppliesToAvailableExtensionPropertiesOperation(),
        new GetPolicyFeatureRolloutPolicyByIdAppliesToByIdsOperation(),
        new GetPolicyFeatureRolloutPolicyByIdAppliesToCountOperation(),
        new ListPolicyFeatureRolloutPolicyByIdAppliesToRefsOperation(),
        new ListPolicyFeatureRolloutPolicyByIdAppliesTosOperation(),
        new RemovePolicyFeatureRolloutPolicyByIdAppliesToByIdRefOperation(),
        new ValidatePolicyFeatureRolloutPolicyByIdAppliesToPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetPolicyFeatureRolloutPolicyByIdAppliesToAvailableExtensionPropertiesRequestModel),
        typeof(GetPolicyFeatureRolloutPolicyByIdAppliesToByIdsRequestModel),
        typeof(ValidatePolicyFeatureRolloutPolicyByIdAppliesToPropertyRequestModel)
    };
}
