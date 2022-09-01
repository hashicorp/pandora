using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("failed")]
    Failed,

    [Description("provisioning")]
    Provisioning,

    [Description("succeeded")]
    Succeeded,
}
