using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ExternalSecuritySolutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExternalSecuritySolutionKindConstant
{
    [Description("AAD")]
    AAD,

    [Description("ATA")]
    ATA,

    [Description("CEF")]
    CEF,
}
