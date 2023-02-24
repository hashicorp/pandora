using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentFetchStatusConstant
{
    [Description("NotFound")]
    NotFound,

    [Description("Success")]
    Success,

    [Description("Unauthorized")]
    Unauthorized,
}
