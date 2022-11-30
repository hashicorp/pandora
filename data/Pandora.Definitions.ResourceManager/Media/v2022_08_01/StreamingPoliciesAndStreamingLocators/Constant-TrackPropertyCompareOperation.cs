using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.StreamingPoliciesAndStreamingLocators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrackPropertyCompareOperationConstant
{
    [Description("Equal")]
    Equal,

    [Description("Unknown")]
    Unknown,
}
