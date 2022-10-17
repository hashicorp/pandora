using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

internal class AliasId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Subscription/aliases/{aliasName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSubscription", "Microsoft.Subscription"),
        ResourceIDSegment.Static("staticAliases", "aliases"),
        ResourceIDSegment.UserSpecified("aliasName"),
    };
}
