using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{
    internal class RecordTypeId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}";

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
                    Name = "resourceGroupName",
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
                    Name = "microsoftNetwork",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Network"
                },

                new()
                {
                    Name = "dnsZones",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "dnsZones"
                },

                new()
                {
                    Name = "zoneName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "recordType",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(RecordTypeConstant)
                },

                new()
                {
                    Name = "relativeRecordSetName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
