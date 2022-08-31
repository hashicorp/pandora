using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Moving")]
    Moving,

    [Description("SoftDeleted")]
    SoftDeleted,

    [Description("SoftDeleting")]
    SoftDeleting,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,
}
