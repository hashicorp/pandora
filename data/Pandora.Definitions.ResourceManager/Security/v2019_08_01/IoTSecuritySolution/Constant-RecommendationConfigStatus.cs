using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolution;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationConfigStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
