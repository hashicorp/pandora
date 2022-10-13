using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessTierConstant
{
    [Description("Cool")]
    Cool,

    [Description("Hot")]
    Hot,

    [Description("Premium")]
    Premium,
}
