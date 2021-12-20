using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum BillingType
    {
        [Description("auths")]
        Auths,
        
        [Description("mau")]
        MonthlyActiveUsers
    }
}