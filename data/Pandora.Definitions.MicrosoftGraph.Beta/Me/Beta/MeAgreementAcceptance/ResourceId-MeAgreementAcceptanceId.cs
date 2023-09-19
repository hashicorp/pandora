// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAgreementAcceptance;

internal class MeAgreementAcceptanceId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/agreementAcceptances/{agreementAcceptanceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAgreementAcceptances", "agreementAcceptances"),
        ResourceIDSegment.UserSpecified("agreementAcceptanceId")
    };
}
