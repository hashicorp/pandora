using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusterSnapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkPluginConstant
{
    [Description("azure")]
    Azure,

    [Description("kubenet")]
    Kubenet,

    [Description("none")]
    None,
}
