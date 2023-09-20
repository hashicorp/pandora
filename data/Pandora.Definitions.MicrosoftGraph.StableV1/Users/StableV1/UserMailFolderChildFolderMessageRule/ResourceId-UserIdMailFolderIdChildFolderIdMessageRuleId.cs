// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderChildFolderMessageRule;

internal class UserIdMailFolderIdChildFolderIdMessageRuleId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/mailFolders/{mailFolderId}/childFolders/{mailFolderId1}/messageRules/{messageRuleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticMailFolders", "mailFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId"),
        ResourceIDSegment.Static("staticChildFolders", "childFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId1"),
        ResourceIDSegment.Static("staticMessageRules", "messageRules"),
        ResourceIDSegment.UserSpecified("messageRuleId")
    };
}
