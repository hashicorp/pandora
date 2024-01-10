using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggeredBuildResultProvisioningStateConstant
{
    [Description("Building")]
    Building,

    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Queuing")]
    Queuing,

    [Description("Succeeded")]
    Succeeded,
}
