using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointAuthModeConstant
{
    [Description("AADToken")]
    AADToken,

    [Description("AMLToken")]
    AMLToken,

    [Description("Key")]
    Key,
}
