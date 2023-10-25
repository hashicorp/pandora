using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ServerDevOpsAudit;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BlobAuditingPolicyStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
