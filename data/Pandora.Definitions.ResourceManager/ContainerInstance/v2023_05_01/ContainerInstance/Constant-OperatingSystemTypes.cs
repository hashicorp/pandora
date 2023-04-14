using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2023_05_01.ContainerInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemTypesConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
