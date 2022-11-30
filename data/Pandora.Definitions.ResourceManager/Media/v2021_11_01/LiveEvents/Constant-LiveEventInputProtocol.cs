using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiveEventInputProtocolConstant
{
    [Description("FragmentedMP4")]
    FragmentedMPFour,

    [Description("RTMP")]
    RTMP,
}
