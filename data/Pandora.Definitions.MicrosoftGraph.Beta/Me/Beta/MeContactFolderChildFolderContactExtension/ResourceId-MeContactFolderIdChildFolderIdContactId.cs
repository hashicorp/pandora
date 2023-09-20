// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeContactFolderChildFolderContactExtension;

internal class MeContactFolderIdChildFolderIdContactId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/contactFolders/{contactFolderId}/childFolders/{contactFolderId1}/contacts/{contactId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticContactFolders", "contactFolders"),
        ResourceIDSegment.UserSpecified("contactFolderId"),
        ResourceIDSegment.Static("staticChildFolders", "childFolders"),
        ResourceIDSegment.UserSpecified("contactFolderId1"),
        ResourceIDSegment.Static("staticContacts", "contacts"),
        ResourceIDSegment.UserSpecified("contactId")
    };
}
