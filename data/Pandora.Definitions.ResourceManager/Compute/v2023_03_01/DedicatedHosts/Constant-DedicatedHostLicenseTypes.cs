using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.DedicatedHosts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DedicatedHostLicenseTypesConstant
{
    [Description("None")]
    None,

    [Description("Windows_Server_Hybrid")]
    WindowsServerHybrid,

    [Description("Windows_Server_Perpetual")]
    WindowsServerPerpetual,
}
