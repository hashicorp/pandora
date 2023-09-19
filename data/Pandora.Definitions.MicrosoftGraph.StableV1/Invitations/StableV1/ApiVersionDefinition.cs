// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Invitations.StableV1;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "StableV1";
    public bool Preview => false;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Invitation.Definition(),
        new InvitationInvitedUser.Definition(),
        new InvitationInvitedUserMailboxSetting.Definition()
    };
}
