// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeLicenseDetail;

internal class MeLicenseDetailId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/licenseDetails/{licenseDetailsId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticLicenseDetails", "licenseDetails"),
        ResourceIDSegment.UserSpecified("licenseDetailsId")
    };
}
