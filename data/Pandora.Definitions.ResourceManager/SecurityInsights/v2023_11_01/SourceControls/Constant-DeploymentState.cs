using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentStateConstant
{
    [Description("Canceling")]
    Canceling,

    [Description("Completed")]
    Completed,

    [Description("In_Progress")]
    InProgress,

    [Description("Queued")]
    Queued,
}
