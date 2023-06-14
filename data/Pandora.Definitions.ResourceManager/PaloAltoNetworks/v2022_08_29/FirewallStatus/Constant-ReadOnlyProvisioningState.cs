using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.FirewallStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadOnlyProvisioningStateConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
