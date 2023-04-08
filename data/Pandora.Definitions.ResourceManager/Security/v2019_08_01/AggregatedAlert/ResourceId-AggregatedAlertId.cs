using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.AggregatedAlert;

internal class AggregatedAlertId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/iotSecuritySolutions/{iotSecuritySolutionName}/analyticsModels/default/aggregatedAlerts/{aggregatedAlertName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSecurity", "Microsoft.Security"),
        ResourceIDSegment.Static("staticIotSecuritySolutions", "iotSecuritySolutions"),
        ResourceIDSegment.UserSpecified("iotSecuritySolutionName"),
        ResourceIDSegment.Static("staticAnalyticsModels", "analyticsModels"),
        ResourceIDSegment.Static("staticDefault", "default"),
        ResourceIDSegment.Static("staticAggregatedAlerts", "aggregatedAlerts"),
        ResourceIDSegment.UserSpecified("aggregatedAlertName"),
    };
}
