using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SyncAgents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncMemberDbTypeConstant
{
    [Description("AzureSqlDatabase")]
    AzureSqlDatabase,

    [Description("SqlServerDatabase")]
    SqlServerDatabase,
}
