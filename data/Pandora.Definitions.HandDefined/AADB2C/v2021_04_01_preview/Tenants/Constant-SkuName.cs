using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    public enum SkuName
    {
        [Description("PremiumP1")]
        PremiumP1,
        
        [Description("PremiumP2")]
        PremiumP2,
        
        [Description("Standard")]
        Standard
    }
}