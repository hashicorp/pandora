using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachineGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlVMGroupImageSkuConstant
{
    [Description("Developer")]
    Developer,

    [Description("Enterprise")]
    Enterprise,
}
