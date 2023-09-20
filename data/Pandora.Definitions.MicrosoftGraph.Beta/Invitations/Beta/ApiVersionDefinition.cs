// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Invitations.Beta;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "Beta";
    public bool Preview => true;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Invitation.Definition(),
        new InvitationInvitedUser.Definition(),
        new InvitationInvitedUserMailboxSetting.Definition(),
        new InvitationInvitedUserSponsor.Definition()
    };
}
