using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlMetadataDiscoveryPipeConstant
{
    [Description("CIM")]
    CIM,

    [Description("Other")]
    Other,

    [Description("PowerShell")]
    PowerShell,

    [Description("SSH")]
    SSH,

    [Description("Unknown")]
    Unknown,

    [Description("VMware")]
    VMware,
}
