using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiIssueAttachment;

internal class ApiIssueId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftApiManagement", "Microsoft.ApiManagement"),
        ResourceIDSegment.Static("staticService", "service"),
        ResourceIDSegment.UserSpecified("serviceName"),
        ResourceIDSegment.Static("staticApis", "apis"),
        ResourceIDSegment.UserSpecified("apiId"),
        ResourceIDSegment.Static("staticIssues", "issues"),
        ResourceIDSegment.UserSpecified("issueId"),
    };
}
