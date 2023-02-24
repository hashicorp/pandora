using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentResultConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Success")]
    Success,
}
