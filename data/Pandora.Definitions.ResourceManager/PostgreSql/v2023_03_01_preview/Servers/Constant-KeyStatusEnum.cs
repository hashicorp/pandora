using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyStatusEnumConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Valid")]
    Valid,
}
