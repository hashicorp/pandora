using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.Proxy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceNameUnavailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
