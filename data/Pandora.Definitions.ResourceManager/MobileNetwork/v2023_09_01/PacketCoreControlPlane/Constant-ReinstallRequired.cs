using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReinstallRequiredConstant
{
    [Description("NotRequired")]
    NotRequired,

    [Description("Required")]
    Required,
}
