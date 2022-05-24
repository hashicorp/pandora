using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Proxy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NameUnavailableReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
