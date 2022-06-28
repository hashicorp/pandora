using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnauthenticatedClientActionVTwoConstant
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
