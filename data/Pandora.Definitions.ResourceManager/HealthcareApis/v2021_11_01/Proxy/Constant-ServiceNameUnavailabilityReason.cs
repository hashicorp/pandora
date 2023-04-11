using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2021_11_01.Proxy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceNameUnavailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
