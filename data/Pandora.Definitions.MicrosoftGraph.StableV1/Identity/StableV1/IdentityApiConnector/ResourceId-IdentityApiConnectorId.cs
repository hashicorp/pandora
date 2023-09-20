// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityApiConnector;

internal class IdentityApiConnectorId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/apiConnectors/{identityApiConnectorId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticApiConnectors", "apiConnectors"),
        ResourceIDSegment.UserSpecified("identityApiConnectorId")
    };
}
