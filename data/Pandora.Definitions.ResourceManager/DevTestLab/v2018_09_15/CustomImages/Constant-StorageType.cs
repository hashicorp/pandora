using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.CustomImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeConstant
{
    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,

    [Description("StandardSSD")]
    StandardSSD,
}
