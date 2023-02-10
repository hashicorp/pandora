using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.StorageTargets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateTypeConstant
{
    [Description("Cancelled")]
    Cancelled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
