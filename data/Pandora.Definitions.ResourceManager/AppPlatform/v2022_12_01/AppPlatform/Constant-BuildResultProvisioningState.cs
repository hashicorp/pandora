using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BuildResultProvisioningStateConstant
{
    [Description("Building")]
    Building,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Queuing")]
    Queuing,

    [Description("Succeeded")]
    Succeeded,
}
