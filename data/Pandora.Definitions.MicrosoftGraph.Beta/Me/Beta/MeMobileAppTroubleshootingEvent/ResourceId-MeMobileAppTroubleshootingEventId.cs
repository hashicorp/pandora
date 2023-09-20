// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMobileAppTroubleshootingEvent;

internal class MeMobileAppTroubleshootingEventId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/mobileAppTroubleshootingEvents/{mobileAppTroubleshootingEventId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticMobileAppTroubleshootingEvents", "mobileAppTroubleshootingEvents"),
        ResourceIDSegment.UserSpecified("mobileAppTroubleshootingEventId")
    };
}
