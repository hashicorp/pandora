using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IotSecuritySolutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationConfigStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
