using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataTypeConstant
{
    [Description("LineString")]
    LineString,

    [Description("MultiPolygon")]
    MultiPolygon,

    [Description("Number")]
    Number,

    [Description("Point")]
    Point,

    [Description("Polygon")]
    Polygon,

    [Description("String")]
    String,
}
