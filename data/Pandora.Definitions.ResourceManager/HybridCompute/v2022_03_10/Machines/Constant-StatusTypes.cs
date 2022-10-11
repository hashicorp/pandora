using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusTypesConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,

    [Description("Error")]
    Error,
}
