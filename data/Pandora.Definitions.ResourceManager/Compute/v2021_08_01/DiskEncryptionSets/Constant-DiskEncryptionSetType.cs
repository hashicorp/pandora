using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.DiskEncryptionSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskEncryptionSetTypeConstant
{
    [Description("ConfidentialVmEncryptedWithCustomerKey")]
    ConfidentialVmEncryptedWithCustomerKey,

    [Description("EncryptionAtRestWithCustomerKey")]
    EncryptionAtRestWithCustomerKey,

    [Description("EncryptionAtRestWithPlatformAndCustomerKeys")]
    EncryptionAtRestWithPlatformAndCustomerKeys,
}
