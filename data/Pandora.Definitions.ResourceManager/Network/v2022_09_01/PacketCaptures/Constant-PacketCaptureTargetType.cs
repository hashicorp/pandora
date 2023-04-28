using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PacketCaptureTargetTypeConstant
{
    [Description("AzureVM")]
    AzureVM,

    [Description("AzureVMSS")]
    AzureVMSS,
}
