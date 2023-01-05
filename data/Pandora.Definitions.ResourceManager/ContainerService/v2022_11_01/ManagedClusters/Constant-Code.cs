using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CodeConstant
{
    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,
}
