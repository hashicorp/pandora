using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseDurationConstant
{
    [Description("Fixed")]
    Fixed,

    [Description("Infinite")]
    Infinite,
}
