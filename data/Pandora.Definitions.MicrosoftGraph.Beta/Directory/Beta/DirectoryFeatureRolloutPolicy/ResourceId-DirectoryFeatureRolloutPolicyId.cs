// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryFeatureRolloutPolicy;

internal class DirectoryFeatureRolloutPolicyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/featureRolloutPolicies/{featureRolloutPolicyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticFeatureRolloutPolicies", "featureRolloutPolicies"),
        ResourceIDSegment.UserSpecified("featureRolloutPolicyId")
    };
}
