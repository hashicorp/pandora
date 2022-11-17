using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PermissionsConstant
{
    [Description("a")]
    A,

    [Description("c")]
    C,

    [Description("d")]
    D,

    [Description("l")]
    L,

    [Description("p")]
    P,

    [Description("r")]
    R,

    [Description("u")]
    U,

    [Description("w")]
    W,
}
