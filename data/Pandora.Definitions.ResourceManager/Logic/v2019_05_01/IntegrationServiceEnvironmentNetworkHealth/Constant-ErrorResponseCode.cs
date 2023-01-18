using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ErrorResponseCodeConstant
{
    [Description("IntegrationServiceEnvironmentNotFound")]
    IntegrationServiceEnvironmentNotFound,

    [Description("InternalServerError")]
    InternalServerError,

    [Description("InvalidOperationId")]
    InvalidOperationId,

    [Description("NotSpecified")]
    NotSpecified,
}
