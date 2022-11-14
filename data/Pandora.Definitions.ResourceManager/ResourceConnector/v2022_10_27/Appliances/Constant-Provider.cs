using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProviderConstant
{
    [Description("HCI")]
    HCI,

    [Description("KubeVirt")]
    KubeVirt,

    [Description("OpenStack")]
    OpenStack,

    [Description("SCVMM")]
    SCVMM,

    [Description("VMWare")]
    VMWare,
}
