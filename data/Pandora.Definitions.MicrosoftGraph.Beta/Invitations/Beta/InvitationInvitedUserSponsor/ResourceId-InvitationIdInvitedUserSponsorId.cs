// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Invitations.Beta.InvitationInvitedUserSponsor;

internal class InvitationIdInvitedUserSponsorId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/invitations/{invitationId}/invitedUserSponsors/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticInvitations", "invitations"),
        ResourceIDSegment.UserSpecified("invitationId"),
        ResourceIDSegment.Static("staticInvitedUserSponsors", "invitedUserSponsors"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
