using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class B2CDirectoryId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.AzureActiveDirectory/b2cDirectories/{directoryName}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
        {
            new()
            {
                Name = "subscriptions",
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
                Name = "resourceGroups",
                Type = ResourceIDSegmentType.Static,
                FixedValue = "resourceGroups"
            },
            new()
            {
                Name = "resourceGroup",
                Type = ResourceIDSegmentType.ResourceGroup
            },
            new()
            {
                Name = "providers",
                Type = ResourceIDSegmentType.Static,
                FixedValue = "providers"
            },
            new()
            {
                Name = "microsoftAzureActiveDirectory",
                Type = ResourceIDSegmentType.Static,
                FixedValue = "Microsoft.AzureActiveDirectory"
            },
            new()
            {
                Name = "b2cDirectories",
                Type = ResourceIDSegmentType.Static,
                FixedValue = "b2cDirectories"
            },
            new()
            {
                Name = "directoryName",
                Type = ResourceIDSegmentType.UserSpecified,
            }
        };
    }
}