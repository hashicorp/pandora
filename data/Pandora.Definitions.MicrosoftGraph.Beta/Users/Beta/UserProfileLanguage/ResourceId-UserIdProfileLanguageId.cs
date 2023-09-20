// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserProfileLanguage;

internal class UserIdProfileLanguageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/profile/languages/{languageProficiencyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticLanguages", "languages"),
        ResourceIDSegment.UserSpecified("languageProficiencyId")
    };
}
