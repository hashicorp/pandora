// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthenticationStrengthPolicyCombinationConfiguration;

internal class PolicyAuthenticationStrengthPolicyIdCombinationConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/authenticationStrengthPolicies/{authenticationStrengthPolicyId}/combinationConfigurations/{authenticationCombinationConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticAuthenticationStrengthPolicies", "authenticationStrengthPolicies"),
        ResourceIDSegment.UserSpecified("authenticationStrengthPolicyId"),
        ResourceIDSegment.Static("staticCombinationConfigurations", "combinationConfigurations"),
        ResourceIDSegment.UserSpecified("authenticationCombinationConfigurationId")
    };
}
