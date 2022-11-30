using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncoderNamedPresetConstant
{
    [Description("AACGoodQualityAudio")]
    AACGoodQualityAudio,

    [Description("AdaptiveStreaming")]
    AdaptiveStreaming,

    [Description("ContentAwareEncoding")]
    ContentAwareEncoding,

    [Description("ContentAwareEncodingExperimental")]
    ContentAwareEncodingExperimental,

    [Description("CopyAllBitrateNonInterleaved")]
    CopyAllBitrateNonInterleaved,

    [Description("H265AdaptiveStreaming")]
    HTwoSixFiveAdaptiveStreaming,

    [Description("H265ContentAwareEncoding")]
    HTwoSixFiveContentAwareEncoding,

    [Description("H265SingleBitrate4K")]
    HTwoSixFiveSingleBitrateFourK,

    [Description("H265SingleBitrate1080p")]
    HTwoSixFiveSingleBitrateOneZeroEightZerop,

    [Description("H265SingleBitrate720p")]
    HTwoSixFiveSingleBitrateSevenTwoZerop,

    [Description("H264MultipleBitrate1080p")]
    HTwoSixFourMultipleBitrateOneZeroEightZerop,

    [Description("H264MultipleBitrateSD")]
    HTwoSixFourMultipleBitrateSD,

    [Description("H264MultipleBitrate720p")]
    HTwoSixFourMultipleBitrateSevenTwoZerop,

    [Description("H264SingleBitrate1080p")]
    HTwoSixFourSingleBitrateOneZeroEightZerop,

    [Description("H264SingleBitrateSD")]
    HTwoSixFourSingleBitrateSD,

    [Description("H264SingleBitrate720p")]
    HTwoSixFourSingleBitrateSevenTwoZerop,
}
