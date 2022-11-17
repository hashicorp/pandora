using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AffinityStrengthConstant
{
    [Description("Must")]
    Must,

    [Description("Should")]
    Should,
}
