// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeContactFolderContactPhoto;

internal class MeContactFolderIdContactId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/contactFolders/{contactFolderId}/contacts/{contactId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticContactFolders", "contactFolders"),
        ResourceIDSegment.UserSpecified("contactFolderId"),
        ResourceIDSegment.Static("staticContacts", "contacts"),
        ResourceIDSegment.UserSpecified("contactId")
    };
}
