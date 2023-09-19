// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Policies.Beta.PolicyAuthenticationMethodsPolicyAuthenticationMethodConfiguration;

internal class PolicyAuthenticationMethodsPolicyAuthenticationMethodConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/{authenticationMethodConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticPolicies", "policies"),
        ResourceIDSegment.Static("staticAuthenticationMethodsPolicy", "authenticationMethodsPolicy"),
        ResourceIDSegment.Static("staticAuthenticationMethodConfigurations", "authenticationMethodConfigurations"),
        ResourceIDSegment.UserSpecified("authenticationMethodConfigurationId")
    };
}
