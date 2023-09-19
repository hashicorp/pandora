// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileCertification;

internal class MeProfileCertificationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/certifications/{personCertificationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticCertifications", "certifications"),
        ResourceIDSegment.UserSpecified("personCertificationId")
    };
}
