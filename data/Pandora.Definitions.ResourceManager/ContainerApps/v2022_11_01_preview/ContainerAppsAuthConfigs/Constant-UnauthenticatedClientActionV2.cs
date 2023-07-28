using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerAppsAuthConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnauthenticatedClientActionV2Constant
{
    [Description("AllowAnonymous")]
    AllowAnonymous,

    [Description("RedirectToLoginPage")]
    RedirectToLoginPage,

    [Description("Return401")]
    ReturnFourZeroOne,

    [Description("Return403")]
    ReturnFourZeroThree,
}
