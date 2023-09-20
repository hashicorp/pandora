// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedAppRegistration;

internal class UserIdManagedAppRegistrationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/managedAppRegistrations/{managedAppRegistrationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticManagedAppRegistrations", "managedAppRegistrations"),
        ResourceIDSegment.UserSpecified("managedAppRegistrationId")
    };
}
