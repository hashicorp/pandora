using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallerRoleConstant
{
    [Description("Admin")]
    Admin,

    [Description("None")]
    None,
}
