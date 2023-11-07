using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_09_06.DicomServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceEventStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("Updating")]
    Updating,
}
