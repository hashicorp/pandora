using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Diagnostic;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HTTPCorrelationProtocolConstant
{
    [Description("Legacy")]
    Legacy,

    [Description("None")]
    None,

    [Description("W3C")]
    WThreeC,
}
