// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryFeatureRolloutPolicyAppliesTo;

internal class DirectoryFeatureRolloutPolicyIdAppliesToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/featureRolloutPolicies/{featureRolloutPolicyId}/appliesTo/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticFeatureRolloutPolicies", "featureRolloutPolicies"),
        ResourceIDSegment.UserSpecified("featureRolloutPolicyId"),
        ResourceIDSegment.Static("staticAppliesTo", "appliesTo"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
