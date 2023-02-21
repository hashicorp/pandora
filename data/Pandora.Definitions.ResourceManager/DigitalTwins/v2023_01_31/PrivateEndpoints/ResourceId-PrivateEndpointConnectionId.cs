using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.PrivateEndpoints;

internal class PrivateEndpointConnectionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DigitalTwins/digitalTwinsInstances/{digitalTwinsInstanceName}/privateEndpointConnections/{privateEndpointConnectionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDigitalTwins", "Microsoft.DigitalTwins"),
        ResourceIDSegment.Static("staticDigitalTwinsInstances", "digitalTwinsInstances"),
        ResourceIDSegment.UserSpecified("digitalTwinsInstanceName"),
        ResourceIDSegment.Static("staticPrivateEndpointConnections", "privateEndpointConnections"),
        ResourceIDSegment.UserSpecified("privateEndpointConnectionName"),
    };
}
