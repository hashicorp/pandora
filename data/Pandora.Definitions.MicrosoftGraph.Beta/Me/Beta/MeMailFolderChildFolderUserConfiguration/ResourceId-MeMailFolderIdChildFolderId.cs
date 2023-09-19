// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolderChildFolderUserConfiguration;

internal class MeMailFolderIdChildFolderId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/mailFolders/{mailFolderId}/childFolders/{mailFolderId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMailFolders", "mailFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId"),
        ResourceIDSegment.Static("staticChildFolders", "childFolders"),
        ResourceIDSegment.UserSpecified("mailFolderId1")
    };
}
