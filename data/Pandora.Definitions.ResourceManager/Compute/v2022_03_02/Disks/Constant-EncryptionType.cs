using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.Disks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionTypeConstant
{
    [Description("EncryptionAtRestWithCustomerKey")]
    EncryptionAtRestWithCustomerKey,

    [Description("EncryptionAtRestWithPlatformAndCustomerKeys")]
    EncryptionAtRestWithPlatformAndCustomerKeys,

    [Description("EncryptionAtRestWithPlatformKey")]
    EncryptionAtRestWithPlatformKey,
}
