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
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroup"),
        ResourceIDSegment.Static("planets", "planets"),
        ResourceIDSegment.Constant("planetName", typeof(PlanetName)),
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