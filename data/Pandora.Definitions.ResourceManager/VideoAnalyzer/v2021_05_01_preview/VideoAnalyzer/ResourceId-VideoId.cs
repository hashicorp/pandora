using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    internal class VideoId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/videoAnalyzers/{accountName}/videos/{videoName}";

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
                    Name = "microsoftMedia",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Media"
                },

                new()
                {
                    Name = "videoAnalyzers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "videoAnalyzers"
                },

                new()
                {
                    Name = "accountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "videos",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "videos"
                },

                new()
                {
                    Name = "videoName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
