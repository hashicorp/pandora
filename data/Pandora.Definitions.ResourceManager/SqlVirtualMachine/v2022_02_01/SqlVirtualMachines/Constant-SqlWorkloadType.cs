using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlWorkloadTypeConstant
{
    [Description("DW")]
    DW,

    [Description("GENERAL")]
    GENERAL,

    [Description("OLTP")]
    OLTP,
}
