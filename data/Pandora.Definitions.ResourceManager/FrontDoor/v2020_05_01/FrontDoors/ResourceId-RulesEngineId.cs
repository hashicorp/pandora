using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    internal class RulesEngineId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/frontDoors/{frontDoorName}/rulesEngines/{rulesEngineName}";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
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
                    Name = "frontDoors",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "frontDoors"
                },

                new()
                {
                    Name = "frontDoorName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "rulesEngines",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "rulesEngines"
                },

                new()
                {
                    Name = "rulesEngineName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
