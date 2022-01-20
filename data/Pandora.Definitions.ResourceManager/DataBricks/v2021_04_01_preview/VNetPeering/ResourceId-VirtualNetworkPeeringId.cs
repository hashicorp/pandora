using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.VNetPeering;

internal class VirtualNetworkPeeringId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Databricks/workspaces/{workspaceName}/virtualNetworkPeerings/{peeringName}";

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
                    Name = "staticMicrosoftDatabricks",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Databricks"
                },

                new()
                {
                    Name = "staticWorkspaces",
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
                    Name = "staticVirtualNetworkPeerings",
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
