using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftDeleteStateConstant
{
    [Description("AlwaysOn")]
    AlwaysOn,

    [Description("Off")]
    Off,

    [Description("On")]
    On,
}
