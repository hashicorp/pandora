using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("4.2")]
    FourPointTwo,

    [Description("4.0")]
    FourPointZero,

    [Description("3.6")]
    ThreePointSix,

    [Description("3.2")]
    ThreePointTwo,
}
