using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimeObjectMetadata;

internal class IntegrationRuntimeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/integrationRuntimes/{integrationRuntimeName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDataFactory", "Microsoft.DataFactory"),
        ResourceIDSegment.Static("staticFactories", "factories"),
        ResourceIDSegment.UserSpecified("factoryName"),
        ResourceIDSegment.Static("staticIntegrationRuntimes", "integrationRuntimes"),
        ResourceIDSegment.UserSpecified("integrationRuntimeName"),
    };
}
