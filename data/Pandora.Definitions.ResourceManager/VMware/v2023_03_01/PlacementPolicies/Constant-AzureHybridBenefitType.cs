using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureHybridBenefitTypeConstant
{
    [Description("None")]
    None,

    [Description("SqlHost")]
    SqlHost,
}
