using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;

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
