using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_08_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnavailableNameReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
