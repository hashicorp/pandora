using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectivityTypeConstant
{
    [Description("LOCAL")]
    LOCAL,

    [Description("PRIVATE")]
    PRIVATE,

    [Description("PUBLIC")]
    PUBLIC,
}
