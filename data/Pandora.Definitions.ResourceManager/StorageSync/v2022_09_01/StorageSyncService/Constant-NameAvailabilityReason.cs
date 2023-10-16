using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.StorageSyncService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NameAvailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
