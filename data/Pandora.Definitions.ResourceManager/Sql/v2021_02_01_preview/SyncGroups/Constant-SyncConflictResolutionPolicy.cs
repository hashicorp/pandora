using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SyncGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncConflictResolutionPolicyConstant
{
    [Description("HubWin")]
    HubWin,

    [Description("MemberWin")]
    MemberWin,
}
