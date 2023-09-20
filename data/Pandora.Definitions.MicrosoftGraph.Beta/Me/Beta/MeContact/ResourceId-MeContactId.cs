// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeContact;

internal class MeContactId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/contacts/{contactId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticContacts", "contacts"),
        ResourceIDSegment.UserSpecified("contactId")
    };
}
