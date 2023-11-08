using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobProvisioningStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Processing")]
    Processing,

    [Description("Succeeded")]
    Succeeded,

    [Description("Suspended")]
    Suspended,
}
