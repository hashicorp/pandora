using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CapacitySkuTierConstant
{
    [Description("AutoPremiumHost")]
    AutoPremiumHost,

    [Description("PBIE_Azure")]
    PBIEAzure,

    [Description("Premium")]
    Premium,
}
