using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTierConstant
{
    [Description("Enterprise")]
    Enterprise,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
