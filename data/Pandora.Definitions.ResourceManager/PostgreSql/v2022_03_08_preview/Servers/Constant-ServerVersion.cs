using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Servers;

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
