using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.SourceControlSyncJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,
}
