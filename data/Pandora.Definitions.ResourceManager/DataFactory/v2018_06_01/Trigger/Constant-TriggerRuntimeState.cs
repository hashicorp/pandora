using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Trigger;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerRuntimeStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Started")]
    Started,

    [Description("Stopped")]
    Stopped,
}
