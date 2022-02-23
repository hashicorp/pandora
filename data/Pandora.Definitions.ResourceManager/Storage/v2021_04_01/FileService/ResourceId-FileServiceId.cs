using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileService;

internal class FileServiceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/{fileServicesName}";

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
                    Name = "staticFileServices",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "fileServices"
                },

                new()
                {
                    Name = "fileServicesName",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(FileServicesNameConstant)
                },

    };
}
