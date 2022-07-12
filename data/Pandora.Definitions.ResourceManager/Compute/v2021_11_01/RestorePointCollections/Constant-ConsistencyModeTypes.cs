using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.RestorePointCollections;

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
