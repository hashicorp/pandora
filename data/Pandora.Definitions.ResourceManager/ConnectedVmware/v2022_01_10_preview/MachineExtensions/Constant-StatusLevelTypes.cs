using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.MachineExtensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusLevelTypesConstant
{
    [Description("Error")]
    Error,

    [Description("Info")]
    Info,

    [Description("Warning")]
    Warning,
}
