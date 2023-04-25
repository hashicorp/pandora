using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.MachineExtensions;

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
