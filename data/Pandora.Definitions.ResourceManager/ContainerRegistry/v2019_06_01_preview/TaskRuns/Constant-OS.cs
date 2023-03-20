using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.TaskRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OSConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
