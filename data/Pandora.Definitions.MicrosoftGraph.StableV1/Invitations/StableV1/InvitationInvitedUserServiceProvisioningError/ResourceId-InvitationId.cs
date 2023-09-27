// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Invitations.StableV1.InvitationInvitedUserServiceProvisioningError;

internal class InvitationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/invitations/{invitationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticInvitations", "invitations"),
        ResourceIDSegment.UserSpecified("invitationId")
    };
}
