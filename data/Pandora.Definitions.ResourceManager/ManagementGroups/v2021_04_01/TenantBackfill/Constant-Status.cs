using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.TenantBackfill;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Cancelled")]
    Cancelled,

    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("NotStarted")]
    NotStarted,

    [Description("NotStartedButGroupsExist")]
    NotStartedButGroupsExist,

    [Description("Started")]
    Started,
}
