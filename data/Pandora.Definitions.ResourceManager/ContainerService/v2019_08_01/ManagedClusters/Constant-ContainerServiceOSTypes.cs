using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerServiceOSTypesConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
