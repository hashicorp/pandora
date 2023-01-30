using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAccountStatusConstant
{
    [Description("NeedsAttention")]
    NeedsAttention,

    [Description("OK")]
    OK,

    [Description("Offline")]
    Offline,

    [Description("Unknown")]
    Unknown,

    [Description("Updating")]
    Updating,
}
