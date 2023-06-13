using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ServerDevOpsAudit;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BlobAuditingPolicyStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
