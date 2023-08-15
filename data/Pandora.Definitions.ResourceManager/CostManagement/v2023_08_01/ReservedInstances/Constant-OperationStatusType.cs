using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.ReservedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusTypeConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,
}
