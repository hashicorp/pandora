// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInferenceClassificationOverride;

internal class UserIdInferenceClassificationOverrideId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/inferenceClassification/overrides/{inferenceClassificationOverrideId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInferenceClassification", "inferenceClassification"),
        ResourceIDSegment.Static("staticOverrides", "overrides"),
        ResourceIDSegment.UserSpecified("inferenceClassificationOverrideId")
    };
}
