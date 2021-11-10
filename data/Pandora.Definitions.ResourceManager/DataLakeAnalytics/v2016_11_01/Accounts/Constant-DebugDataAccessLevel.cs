using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DebugDataAccessLevelConstant
    {
        [Description("All")]
        All,

        [Description("Customer")]
        Customer,

        [Description("None")]
        None,
    }
}
