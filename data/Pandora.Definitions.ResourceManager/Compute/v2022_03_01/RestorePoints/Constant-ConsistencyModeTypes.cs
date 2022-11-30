using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.RestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConsistencyModeTypesConstant
{
    [Description("ApplicationConsistent")]
    ApplicationConsistent,

    [Description("CrashConsistent")]
    CrashConsistent,

    [Description("FileSystemConsistent")]
    FileSystemConsistent,
}
