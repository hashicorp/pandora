using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityLevelConstant
{
    [Description("SL150")]
    SLOneFiveZero,

    [Description("SL3000")]
    SLThreeThousand,

    [Description("SL2000")]
    SLTwoThousand,

    [Description("Unknown")]
    Unknown,
}
