using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsolationModeConstant
{
    [Description("AllowInternetOutbound")]
    AllowInternetOutbound,

    [Description("AllowOnlyApprovedOutbound")]
    AllowOnlyApprovedOutbound,

    [Description("Disabled")]
    Disabled,
}
