using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.Proxy;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceNameUnavailabilityReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
