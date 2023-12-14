// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeContactFolderChildFolderContact;

internal class MeContactFolderIdChildFolderId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/contactFolders/{contactFolderId}/childFolders/{contactFolderId1}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticContactFolders", "contactFolders"),
        ResourceIDSegment.UserSpecified("contactFolderId"),
        ResourceIDSegment.Static("staticChildFolders", "childFolders"),
        ResourceIDSegment.UserSpecified("contactFolderId1")
    };
}
