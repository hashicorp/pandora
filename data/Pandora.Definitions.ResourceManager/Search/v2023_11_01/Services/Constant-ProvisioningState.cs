using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2023_11_01.Services;

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
