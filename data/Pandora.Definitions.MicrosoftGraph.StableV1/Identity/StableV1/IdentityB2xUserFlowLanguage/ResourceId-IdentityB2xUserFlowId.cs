// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguage;

internal class IdentityB2xUserFlowId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/b2xUserFlows/{b2xIdentityUserFlowId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticB2xUserFlows", "b2xUserFlows"),
        ResourceIDSegment.UserSpecified("b2xIdentityUserFlowId")
    };
}
