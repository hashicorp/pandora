using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_04_02.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileFormatConstant
{
    [Description("VHD")]
    VHD,

    [Description("VHDX")]
    VHDX,
}
