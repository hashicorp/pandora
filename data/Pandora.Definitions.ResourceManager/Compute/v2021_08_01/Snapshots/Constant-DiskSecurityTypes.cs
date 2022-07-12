using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskSecurityTypesConstant
{
    [Description("ConfidentialVM_DiskEncryptedWithCustomerKey")]
    ConfidentialVMDiskEncryptedWithCustomerKey,

    [Description("ConfidentialVM_DiskEncryptedWithPlatformKey")]
    ConfidentialVMDiskEncryptedWithPlatformKey,

    [Description("ConfidentialVM_VMGuestStateOnlyEncryptedWithPlatformKey")]
    ConfidentialVMVMGuestStateOnlyEncryptedWithPlatformKey,

    [Description("TrustedLaunch")]
    TrustedLaunch,
}
