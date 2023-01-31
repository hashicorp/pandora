using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstallationImpactConstant
{
    [Description("DeviceRebooted")]
    DeviceRebooted,

    [Description("KubernetesWorkloadsDown")]
    KubernetesWorkloadsDown,

    [Description("None")]
    None,
}
