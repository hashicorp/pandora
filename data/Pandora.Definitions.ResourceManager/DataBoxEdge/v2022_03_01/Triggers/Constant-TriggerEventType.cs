using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Triggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerEventTypeConstant
{
    [Description("FileEvent")]
    FileEvent,

    [Description("PeriodicTimerEvent")]
    PeriodicTimerEvent,
}
