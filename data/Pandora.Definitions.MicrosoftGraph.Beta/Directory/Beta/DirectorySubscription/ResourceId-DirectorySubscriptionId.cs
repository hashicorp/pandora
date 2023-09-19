// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectorySubscription;

internal class DirectorySubscriptionId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/subscriptions/{companySubscriptionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.UserSpecified("companySubscriptionId")
    };
}
