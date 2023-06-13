using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CapabilityGroupConstant
{
    [Description("supportedEditions")]
    SupportedEditions,

    [Description("supportedElasticPoolEditions")]
    SupportedElasticPoolEditions,

    [Description("supportedInstancePoolEditions")]
    SupportedInstancePoolEditions,

    [Description("supportedManagedInstanceEditions")]
    SupportedManagedInstanceEditions,

    [Description("supportedManagedInstanceVersions")]
    SupportedManagedInstanceVersions,
}
