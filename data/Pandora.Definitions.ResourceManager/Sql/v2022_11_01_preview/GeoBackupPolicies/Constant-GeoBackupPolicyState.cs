using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.GeoBackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoBackupPolicyStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
