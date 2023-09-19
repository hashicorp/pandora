// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileWebAccount;

internal class MeProfileWebAccountId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/profile/webAccounts/{webAccountId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticProfile", "profile"),
        ResourceIDSegment.Static("staticWebAccounts", "webAccounts"),
        ResourceIDSegment.UserSpecified("webAccountId")
    };
}
