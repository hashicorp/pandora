using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.IncrementalRestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemTypesConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
