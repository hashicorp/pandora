using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.WorkflowResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowStatusConstant
{
    [Description("aborted")]
    Aborted,

    [Description("active")]
    Active,

    [Description("expired")]
    Expired,

    [Description("failed")]
    Failed,

    [Description("succeeded")]
    Succeeded,
}
