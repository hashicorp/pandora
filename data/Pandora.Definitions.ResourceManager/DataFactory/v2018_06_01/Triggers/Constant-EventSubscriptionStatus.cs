using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventSubscriptionStatusConstant
{
    [Description("Deprovisioning")]
    Deprovisioning,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Provisioning")]
    Provisioning,

    [Description("Unknown")]
    Unknown,
}
