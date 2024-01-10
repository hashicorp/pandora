// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Invitations.Beta.InvitationInvitedUserSponsor;

internal class Definition : ResourceDefinition
{
    public string Name => "InvitationInvitedUserSponsor";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetInvitationByIdInvitedUserSponsorByIdOperation(),
        new GetInvitationByIdInvitedUserSponsorCountOperation(),
        new ListInvitationByIdInvitedUserSponsorsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
