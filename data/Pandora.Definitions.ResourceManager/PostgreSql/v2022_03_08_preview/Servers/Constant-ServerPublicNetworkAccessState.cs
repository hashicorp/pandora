using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerPublicNetworkAccessStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
