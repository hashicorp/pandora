using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkFunction.v2022_08_01.CollectorPolicies;

internal class CollectorPolicyId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkFunction/azureTrafficCollectors/{azureTrafficCollectorName}/collectorPolicies/{collectorPolicyName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetworkFunction", "Microsoft.NetworkFunction"),
        ResourceIDSegment.Static("staticAzureTrafficCollectors", "azureTrafficCollectors"),
        ResourceIDSegment.UserSpecified("azureTrafficCollectorName"),
        ResourceIDSegment.Static("staticCollectorPolicies", "collectorPolicies"),
        ResourceIDSegment.UserSpecified("collectorPolicyName"),
    };
}
