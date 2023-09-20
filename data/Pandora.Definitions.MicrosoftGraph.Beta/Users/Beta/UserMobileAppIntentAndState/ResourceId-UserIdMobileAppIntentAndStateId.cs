// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserMobileAppIntentAndState;

internal class UserIdMobileAppIntentAndStateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/mobileAppIntentAndStates/{mobileAppIntentAndStateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticMobileAppIntentAndStates", "mobileAppIntentAndStates"),
        ResourceIDSegment.UserSpecified("mobileAppIntentAndStateId")
    };
}
