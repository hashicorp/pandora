using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Deleted")]
    Deleted,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Suspended")]
    Suspended,
}
