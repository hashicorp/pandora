using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncMemberDbTypeConstant
{
    [Description("AzureSqlDatabase")]
    AzureSqlDatabase,

    [Description("SqlServerDatabase")]
    SqlServerDatabase,
}
