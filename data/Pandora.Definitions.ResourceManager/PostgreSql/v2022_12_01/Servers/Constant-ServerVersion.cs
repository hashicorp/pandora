using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_12_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("14")]
    OneFour,

    [Description("11")]
    OneOne,

    [Description("13")]
    OneThree,

    [Description("12")]
    OneTwo,
}
