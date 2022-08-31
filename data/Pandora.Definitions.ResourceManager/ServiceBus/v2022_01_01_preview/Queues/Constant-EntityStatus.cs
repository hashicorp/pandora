using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2022_01_01_preview.Queues;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Disabled")]
    Disabled,

    [Description("ReceiveDisabled")]
    ReceiveDisabled,

    [Description("Renaming")]
    Renaming,

    [Description("Restoring")]
    Restoring,

    [Description("SendDisabled")]
    SendDisabled,

    [Description("Unknown")]
    Unknown,
}
