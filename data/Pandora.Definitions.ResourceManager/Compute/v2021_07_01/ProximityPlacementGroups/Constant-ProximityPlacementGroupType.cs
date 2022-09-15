using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.ProximityPlacementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProximityPlacementGroupTypeConstant
{
    [Description("Standard")]
    Standard,

    [Description("Ultra")]
    Ultra,
}
