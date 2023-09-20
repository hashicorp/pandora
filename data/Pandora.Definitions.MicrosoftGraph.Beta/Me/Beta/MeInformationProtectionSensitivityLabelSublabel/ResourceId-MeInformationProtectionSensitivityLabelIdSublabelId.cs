// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionSensitivityLabelSublabel;

internal class MeInformationProtectionSensitivityLabelIdSublabelId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/informationProtection/sensitivityLabels/{sensitivityLabelId}/sublabels/{sensitivityLabelId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticSensitivityLabels", "sensitivityLabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId"),
        ResourceIDSegment.Static("staticSublabels", "sublabels"),
        ResourceIDSegment.UserSpecified("sensitivityLabelId1")
    };
}
