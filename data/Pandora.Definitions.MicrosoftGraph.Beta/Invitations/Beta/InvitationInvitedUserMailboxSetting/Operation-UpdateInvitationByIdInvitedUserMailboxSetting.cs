// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Invitations.Beta.InvitationInvitedUserMailboxSetting;

internal class UpdateInvitationByIdInvitedUserMailboxSettingOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MailboxSettingsModel);
    public override ResourceID? ResourceId() => new InvitationId();
    public override Type? ResponseObject() => typeof(MailboxSettingsModel);
    public override string? UriSuffix() => "/invitedUser/mailboxSettings";
}
