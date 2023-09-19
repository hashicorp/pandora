// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInferenceClassificationOverride;

internal class MeInferenceClassificationOverrideId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/inferenceClassification/overrides/{inferenceClassificationOverrideId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInferenceClassification", "inferenceClassification"),
        ResourceIDSegment.Static("staticOverrides", "overrides"),
        ResourceIDSegment.UserSpecified("inferenceClassificationOverrideId")
    };
}
