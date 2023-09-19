// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderMessageRule;

internal class MeMailFolderIdMessageRuleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/mailFolders/{mailFolderId}/messageRules/{messageRuleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMailFolders", "mailFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId"),
        ResourceIDSegment.Static("staticMessageRules", "messageRules"),
        ResourceIDSegment.UserSpecified("messageRuleId")
    };
}
