using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Forecast;

internal class ExternalCloudProviderTypeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.CostManagement/{externalCloudProviderType}/{externalCloudProviderId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftCostManagement",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CostManagement"
                },

                new()
                {
                    Name = "externalCloudProviderType",
                    Type = ResourceIDSegmentType.Constant,
                    ConstantReference = typeof(ExternalCloudProviderTypeConstant)
                },

                new()
                {
                    Name = "externalCloudProviderId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
