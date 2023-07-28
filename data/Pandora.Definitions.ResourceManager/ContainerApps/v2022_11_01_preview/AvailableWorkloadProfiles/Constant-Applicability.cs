using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.AvailableWorkloadProfiles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicabilityConstant
{
    [Description("Custom")]
    Custom,

    [Description("LocationDefault")]
    LocationDefault,
}
