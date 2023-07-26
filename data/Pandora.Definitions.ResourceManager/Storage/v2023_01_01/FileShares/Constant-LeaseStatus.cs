using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseStatusConstant
{
    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
