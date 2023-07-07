using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("15")]
    OneFive,

    [Description("14")]
    OneFour,

    [Description("11")]
    OneOne,

    [Description("13")]
    OneThree,

    [Description("12")]
    OneTwo,
}
