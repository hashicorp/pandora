using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering
{
    internal class VirtualNetworkPeeringId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Databricks/workspaces/{workspaceName}/virtualNetworkPeerings/{peeringName}";

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
                    Name = "microsoftDatabricks",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Databricks"
                },

                new()
                {
                    Name = "workspaces",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "workspaces"
                },

                new()
                {
                    Name = "workspaceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "virtualNetworkPeerings",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "virtualNetworkPeerings"
                },

                new()
                {
                    Name = "peeringName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
