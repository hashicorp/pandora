using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Disabled")]
    Disabled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,
}
