// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionPolicyLabel;

internal class MeInformationProtectionPolicyLabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/informationProtection/policy/labels/{informationProtectionLabelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticPolicy", "policy"),
        ResourceIDSegment.Static("staticLabels", "labels"),
        ResourceIDSegment.UserSpecified("informationProtectionLabelId")
    };
}
