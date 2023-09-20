// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMailFolderChildFolderUserConfiguration;

internal class UserIdMailFolderIdChildFolderIdUserConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/mailFolders/{mailFolderId}/childFolders/{mailFolderId1}/userConfigurations/{userConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticMailFolders", "mailFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId"),
        ResourceIDSegment.Static("staticChildFolders", "childFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId1"),
        ResourceIDSegment.Static("staticUserConfigurations", "userConfigurations"),
        ResourceIDSegment.UserSpecified("userConfigurationId")
    };
}
