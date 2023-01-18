using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationServiceEnvironmentAccessEndpointTypeConstant
{
    [Description("External")]
    External,

    [Description("Internal")]
    Internal,

    [Description("NotSpecified")]
    NotSpecified,
}
