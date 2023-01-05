using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("ConfiguringProtection")]
    ConfiguringProtection,

    [Description("ConfiguringProtectionFailed")]
    ConfiguringProtectionFailed,

    [Description("ProtectionConfigured")]
    ProtectionConfigured,

    [Description("ProtectionStopped")]
    ProtectionStopped,

    [Description("SoftDeleted")]
    SoftDeleted,

    [Description("SoftDeleting")]
    SoftDeleting,
}
