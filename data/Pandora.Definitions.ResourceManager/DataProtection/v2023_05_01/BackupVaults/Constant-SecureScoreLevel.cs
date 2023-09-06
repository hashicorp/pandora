using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecureScoreLevelConstant
{
    [Description("Adequate")]
    Adequate,

    [Description("Maximum")]
    Maximum,

    [Description("Minimum")]
    Minimum,

    [Description("None")]
    None,

    [Description("NotSupported")]
    NotSupported,
}
