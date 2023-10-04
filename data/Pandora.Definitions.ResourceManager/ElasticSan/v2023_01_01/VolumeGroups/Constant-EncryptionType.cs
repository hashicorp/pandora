using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionTypeConstant
{
    [Description("EncryptionAtRestWithCustomerManagedKey")]
    EncryptionAtRestWithCustomerManagedKey,

    [Description("EncryptionAtRestWithPlatformKey")]
    EncryptionAtRestWithPlatformKey,
}
