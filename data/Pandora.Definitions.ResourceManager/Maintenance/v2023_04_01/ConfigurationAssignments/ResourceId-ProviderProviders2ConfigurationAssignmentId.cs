using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.ConfigurationAssignments;

internal class ProviderProviders2ConfigurationAssignmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.UserSpecified("providerName"),
        ResourceIDSegment.UserSpecified("resourceParentType"),
        ResourceIDSegment.UserSpecified("resourceParentName"),
        ResourceIDSegment.UserSpecified("resourceType"),
        ResourceIDSegment.UserSpecified("resourceName"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMaintenance", "Microsoft.Maintenance"),
        ResourceIDSegment.Static("staticConfigurationAssignments", "configurationAssignments"),
        ResourceIDSegment.UserSpecified("configurationAssignmentName"),
    };
}
