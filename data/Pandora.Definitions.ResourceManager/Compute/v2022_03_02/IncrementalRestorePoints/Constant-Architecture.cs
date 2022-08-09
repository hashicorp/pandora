using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArchitectureConstant
{
    [Description("Arm64")]
    ArmSixFour,

    [Description("x64")]
    XSixFour,
}
