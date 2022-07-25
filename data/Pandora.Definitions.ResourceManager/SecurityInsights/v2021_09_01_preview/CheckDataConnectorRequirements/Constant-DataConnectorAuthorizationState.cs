using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.CheckDataConnectorRequirements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectorAuthorizationStateConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Valid")]
    Valid,
}
