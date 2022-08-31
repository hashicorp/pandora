using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SignedResourceTypesConstant
{
    [Description("c")]
    C,

    [Description("o")]
    O,

    [Description("s")]
    S,
}
