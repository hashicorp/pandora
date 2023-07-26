using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccountStatusConstant
{
    [Description("available")]
    Available,

    [Description("unavailable")]
    Unavailable,
}
