using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScheduleActionTypeConstant
{
    [Description("CreateJob")]
    CreateJob,

    [Description("CreateMonitor")]
    CreateMonitor,

    [Description("InvokeBatchEndpoint")]
    InvokeBatchEndpoint,
}
