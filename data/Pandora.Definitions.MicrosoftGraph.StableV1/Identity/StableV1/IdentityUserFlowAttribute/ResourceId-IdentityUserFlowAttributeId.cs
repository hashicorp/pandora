// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityUserFlowAttribute;

internal class IdentityUserFlowAttributeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/userFlowAttributes/{identityUserFlowAttributeId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticUserFlowAttributes", "userFlowAttributes"),
        ResourceIDSegment.UserSpecified("identityUserFlowAttributeId")
    };
}
