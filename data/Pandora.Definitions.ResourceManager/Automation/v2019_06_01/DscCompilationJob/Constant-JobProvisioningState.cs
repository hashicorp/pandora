using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.DscCompilationJob;

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
