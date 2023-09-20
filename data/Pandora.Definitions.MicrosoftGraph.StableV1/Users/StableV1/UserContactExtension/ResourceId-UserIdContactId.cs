// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserContactExtension;

internal class UserIdContactId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/contacts/{contactId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticContacts", "contacts"),
        ResourceIDSegment.UserSpecified("contactId")
    };
}
