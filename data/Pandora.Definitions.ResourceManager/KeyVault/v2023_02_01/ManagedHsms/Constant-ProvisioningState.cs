using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Activated")]
    Activated,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Provisioning")]
    Provisioning,

    [Description("Restoring")]
    Restoring,

    [Description("SecurityDomainRestore")]
    SecurityDomainRestore,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
