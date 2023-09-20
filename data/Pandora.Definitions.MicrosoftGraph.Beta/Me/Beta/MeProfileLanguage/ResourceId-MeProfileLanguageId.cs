// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileLanguage;

internal class MeProfileLanguageId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/languages/{languageProficiencyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticLanguages", "languages"),
        ResourceIDSegment.UserSpecified("languageProficiencyId")
    };
}
