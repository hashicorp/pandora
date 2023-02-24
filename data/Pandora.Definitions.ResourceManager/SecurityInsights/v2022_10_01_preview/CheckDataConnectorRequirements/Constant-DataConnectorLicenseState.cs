using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.CheckDataConnectorRequirements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectorLicenseStateConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Unknown")]
    Unknown,

    [Description("Valid")]
    Valid,
}
