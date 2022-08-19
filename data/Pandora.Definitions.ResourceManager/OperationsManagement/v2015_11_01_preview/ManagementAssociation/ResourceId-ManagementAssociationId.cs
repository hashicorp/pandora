using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.ManagementAssociation;

internal class ManagementAssociationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.OperationsManagement/managementAssociations/{managementAssociationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.UserSpecified("providerName"),
        ResourceIDSegment.UserSpecified("resourceType"),
        ResourceIDSegment.UserSpecified("resourceName"),
        ResourceIDSegment.Static("staticProviders2", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftOperationsManagement", "Microsoft.OperationsManagement"),
        ResourceIDSegment.Static("staticManagementAssociations", "managementAssociations"),
        ResourceIDSegment.UserSpecified("managementAssociationName"),
    };
}
