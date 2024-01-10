using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01.JobDefinitions;

internal class JobDefinitionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageMover/storageMovers/{storageMoverName}/projects/{projectName}/jobDefinitions/{jobDefinitionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftStorageMover", "Microsoft.StorageMover"),
        ResourceIDSegment.Static("staticStorageMovers", "storageMovers"),
        ResourceIDSegment.UserSpecified("storageMoverName"),
        ResourceIDSegment.Static("staticProjects", "projects"),
        ResourceIDSegment.UserSpecified("projectName"),
        ResourceIDSegment.Static("staticJobDefinitions", "jobDefinitions"),
        ResourceIDSegment.UserSpecified("jobDefinitionName"),
    };
}
