// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationTemporaryAccessPassMethod;

internal class MeAuthenticationTemporaryAccessPassMethodId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/authentication/temporaryAccessPassMethods/{temporaryAccessPassAuthenticationMethodId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticAuthentication", "authentication"),
        ResourceIDSegment.Static("staticTemporaryAccessPassMethods", "temporaryAccessPassMethods"),
        ResourceIDSegment.UserSpecified("temporaryAccessPassAuthenticationMethodId")
    };
}
