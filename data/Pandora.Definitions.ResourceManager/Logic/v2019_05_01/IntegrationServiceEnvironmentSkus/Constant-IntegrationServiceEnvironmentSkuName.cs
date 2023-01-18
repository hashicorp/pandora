using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationServiceEnvironmentSkuNameConstant
{
    [Description("Developer")]
    Developer,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Premium")]
    Premium,
}
