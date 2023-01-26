using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.ApplicationTypeVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterVersionsEnvironmentConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
