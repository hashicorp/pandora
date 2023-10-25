using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncConflictResolutionPolicyConstant
{
    [Description("HubWin")]
    HubWin,

    [Description("MemberWin")]
    MemberWin,
}
