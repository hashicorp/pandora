using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.ProximityPlacementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusLevelTypesConstant
{
    [Description("Error")]
    Error,

    [Description("Info")]
    Info,

    [Description("Warning")]
    Warning,
}
