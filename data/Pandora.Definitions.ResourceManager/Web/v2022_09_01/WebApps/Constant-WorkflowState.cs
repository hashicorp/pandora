using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

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
