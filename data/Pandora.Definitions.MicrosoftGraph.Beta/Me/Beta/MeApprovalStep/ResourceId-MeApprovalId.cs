// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeApprovalStep;

internal class MeApprovalId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/approvals/{approvalId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticApprovals", "approvals"),
        ResourceIDSegment.UserSpecified("approvalId")
    };
}
