using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.DiscoveredSecuritySolutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityFamilyConstant
{
    [Description("Ngfw")]
    Ngfw,

    [Description("SaasWaf")]
    SaasWaf,

    [Description("Va")]
    Va,

    [Description("Waf")]
    Waf,
}
