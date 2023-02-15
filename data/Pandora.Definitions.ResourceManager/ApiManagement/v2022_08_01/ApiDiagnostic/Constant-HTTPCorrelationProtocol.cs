using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiDiagnostic;

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
