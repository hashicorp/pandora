// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileCertification;

internal class UserIdProfileCertificationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/certifications/{personCertificationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticCertifications", "certifications"),
        ResourceIDSegment.UserSpecified("personCertificationId")
    };
}
