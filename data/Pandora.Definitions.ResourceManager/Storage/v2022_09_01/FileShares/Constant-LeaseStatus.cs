using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseStatusConstant
{
    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
