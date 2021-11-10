using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DataLakeStoreAccountStateConstant
    {
        [Description("Active")]
        Active,

        [Description("Suspended")]
        Suspended,
    }
}
