using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_05_02.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallerRoleConstant
{
    [Description("Admin")]
    Admin,

    [Description("None")]
    None,
}
