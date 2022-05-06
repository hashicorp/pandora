using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueService;

internal class QueueId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/queueServices/default/queues/{queueName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticSubscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },

                new()
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId
                },

                new()
                {
                    Name = "staticResourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },

                new()
                {
                    Name = "resourceGroupName",
                    Type = ResourceIDSegmentType.ResourceGroup
                },

                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftStorage",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Storage"
                },

                new()
                {
                    Name = "staticStorageAccounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "storageAccounts"
                },

                new()
                {
                    Name = "accountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticQueueServices",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "queueServices"
                },

                new()
                {
                    Name = "staticDefault",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "default"
                },

                new()
                {
                    Name = "staticQueues",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "queues"
                },

                new()
                {
                    Name = "queueName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
