// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMobileAppIntentAndState;

internal class MeMobileAppIntentAndStateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/mobileAppIntentAndStates/{mobileAppIntentAndStateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMobileAppIntentAndStates", "mobileAppIntentAndStates"),
        ResourceIDSegment.UserSpecified("mobileAppIntentAndStateId")
    };
}
