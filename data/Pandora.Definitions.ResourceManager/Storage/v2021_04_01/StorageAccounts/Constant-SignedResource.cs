using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignedResourceConstant
{
    [Description("b")]
    B,

    [Description("c")]
    C,

    [Description("f")]
    F,

    [Description("s")]
    S,
}
