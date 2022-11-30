using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AacAudioProfileConstant
{
    [Description("AacLc")]
    AacLc,

    [Description("HeAacV1")]
    HeAacVOne,

    [Description("HeAacV2")]
    HeAacVTwo,
}
