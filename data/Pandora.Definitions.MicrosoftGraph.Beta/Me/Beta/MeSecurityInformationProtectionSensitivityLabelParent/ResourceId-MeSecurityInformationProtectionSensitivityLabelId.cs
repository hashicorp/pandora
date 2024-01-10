// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeSecurityInformationProtectionSensitivityLabelParent;

internal class MeSecurityInformationProtectionSensitivityLabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/security/informationProtection/sensitivityLabels/{sensitivityLabelId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticSecurity", "security"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticSensitivityLabels", "sensitivityLabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId")
    };
}
