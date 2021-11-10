using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DataLakeAnalyticsAccountStateConstant
    {
        [Description("Active")]
        Active,

        [Description("Suspended")]
        Suspended,
    }
}
