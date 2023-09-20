// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionDataLossPreventionPolicy;

internal class MeInformationProtectionDataLossPreventionPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/informationProtection/dataLossPreventionPolicies/{dataLossPreventionPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticDataLossPreventionPolicies", "dataLossPreventionPolicies"),
        ResourceIDSegment.UserSpecified("dataLossPreventionPolicyId")
    };
}
