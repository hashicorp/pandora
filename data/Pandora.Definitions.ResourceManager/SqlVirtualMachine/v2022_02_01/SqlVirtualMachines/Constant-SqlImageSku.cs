using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlImageSkuConstant
{
    [Description("Developer")]
    Developer,

    [Description("Enterprise")]
    Enterprise,

    [Description("Express")]
    Express,

    [Description("Standard")]
    Standard,

    [Description("Web")]
    Web,
}
