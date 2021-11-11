using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ExecutionStatusConstant
    {
        [Description("Completed")]
        Completed,

        [Description("DataNotAvailable")]
        DataNotAvailable,

        [Description("Failed")]
        Failed,

        [Description("InProgress")]
        InProgress,

        [Description("NewDataNotAvailable")]
        NewDataNotAvailable,

        [Description("Queued")]
        Queued,

        [Description("Timeout")]
        Timeout,
    }
}
