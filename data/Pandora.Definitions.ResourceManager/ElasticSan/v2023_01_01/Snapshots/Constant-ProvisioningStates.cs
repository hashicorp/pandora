using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStatesConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
