using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.TrustedAccess;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrustedAccessRoleBindingProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
