using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NICTypeConstant
{
    [Description("e1000")]
    EOneThousand,

    [Description("e1000e")]
    EOneThousande,

    [Description("pcnet32")]
    PcnetThreeTwo,

    [Description("vmxnet")]
    VMxnet,

    [Description("vmxnet3")]
    VMxnetThree,

    [Description("vmxnet2")]
    VMxnetTwo,
}
