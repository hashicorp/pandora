using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SpatialTypeConstant
{
    [Description("LineString")]
    LineString,

    [Description("MultiPolygon")]
    MultiPolygon,

    [Description("Point")]
    Point,

    [Description("Polygon")]
    Polygon,
}
