using System.Collections.Generic;
using System.ComponentModel;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping;

public class ExampleResourceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/planets/{planetName}";

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
            Type = ResourceIDSegmentType.SubscriptionId,
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
            Type = ResourceIDSegmentType.ResourceGroup,
        },
        new()
        {
            Name = "planets",
            Type = ResourceIDSegmentType.Static,
            FixedValue = "planets"
        },
        new()
        {
            Name = "planetName",
            Type = ResourceIDSegmentType.Constant,
            ConstantReference = typeof(PlanetName),
        }
    };
}

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
public enum PlanetName
{
    [Description("earth")]
    Earth,

    [Description("mars")]
    Mars,
}