using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerAppsAuthConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ForwardProxyConventionConstant
{
    [Description("Custom")]
    Custom,

    [Description("NoProxy")]
    NoProxy,

    [Description("Standard")]
    Standard,
}
