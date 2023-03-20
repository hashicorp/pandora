using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BaseImageTriggerTypeConstant
{
    [Description("All")]
    All,

    [Description("Runtime")]
    Runtime,
}
