using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LicenseTypeConstant
{
    [Description("NoLicenseType")]
    NoLicenseType,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("WindowsServer")]
    WindowsServer,
}
