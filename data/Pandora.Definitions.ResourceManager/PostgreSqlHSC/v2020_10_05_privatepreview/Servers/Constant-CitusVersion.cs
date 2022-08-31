using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CitusVersionConstant
{
    [Description("8.3")]
    EightPointThree,

    [Description("9.5")]
    NinePointFive,

    [Description("9.4")]
    NinePointFour,

    [Description("9.1")]
    NinePointOne,

    [Description("9.3")]
    NinePointThree,

    [Description("9.2")]
    NinePointTwo,

    [Description("9.0")]
    NinePointZero,
}
