using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPApplicationServerInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationServerVirtualMachineTypeConstant
{
    [Description("Active")]
    Active,

    [Description("Standby")]
    Standby,

    [Description("Unknown")]
    Unknown,
}
