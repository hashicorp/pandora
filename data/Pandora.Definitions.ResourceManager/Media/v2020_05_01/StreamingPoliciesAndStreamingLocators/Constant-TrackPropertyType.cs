using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingPoliciesAndStreamingLocators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrackPropertyTypeConstant
{
    [Description("FourCC")]
    FourCC,

    [Description("Unknown")]
    Unknown,
}
