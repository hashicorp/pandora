using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

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
