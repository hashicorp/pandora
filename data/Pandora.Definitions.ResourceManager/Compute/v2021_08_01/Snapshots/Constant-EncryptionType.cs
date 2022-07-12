using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Snapshots;

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
