using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2021_11_30.DedicatedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyTypeConstant
{
    [Description("Allocating")]
    Allocating,

    [Description("CheckingQuota")]
    CheckingQuota,

    [Description("Connecting")]
    Connecting,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Provisioning")]
    Provisioning,

    [Description("Succeeded")]
    Succeeded,
}
