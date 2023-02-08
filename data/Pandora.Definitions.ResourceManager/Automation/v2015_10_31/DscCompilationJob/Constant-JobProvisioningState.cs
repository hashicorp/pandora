using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.DscCompilationJob;

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
