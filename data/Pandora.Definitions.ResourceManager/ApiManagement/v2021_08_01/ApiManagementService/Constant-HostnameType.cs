using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostnameTypeConstant
{
    [Description("DeveloperPortal")]
    DeveloperPortal,

    [Description("Management")]
    Management,

    [Description("Portal")]
    Portal,

    [Description("Proxy")]
    Proxy,

    [Description("Scm")]
    Scm,
}
