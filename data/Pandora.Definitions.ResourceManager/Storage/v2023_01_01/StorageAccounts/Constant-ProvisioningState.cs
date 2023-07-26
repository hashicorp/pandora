using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("ResolvingDNS")]
    ResolvingDNS,

    [Description("Succeeded")]
    Succeeded,
}
