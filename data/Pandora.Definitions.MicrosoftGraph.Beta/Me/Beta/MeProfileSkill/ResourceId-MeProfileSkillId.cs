// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileSkill;

internal class MeProfileSkillId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/skills/{skillProficiencyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticSkills", "skills"),
        ResourceIDSegment.UserSpecified("skillProficiencyId")
    };
}
