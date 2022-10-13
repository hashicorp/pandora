using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseStatusConstant
{
    [Description("Locked")]
    Locked,

    [Description("Unlocked")]
    Unlocked,
}
