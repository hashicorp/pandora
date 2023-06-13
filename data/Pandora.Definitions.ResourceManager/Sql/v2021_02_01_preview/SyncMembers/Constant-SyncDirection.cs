using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SyncMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncDirectionConstant
{
    [Description("Bidirectional")]
    Bidirectional,

    [Description("OneWayHubToMember")]
    OneWayHubToMember,

    [Description("OneWayMemberToHub")]
    OneWayMemberToHub,
}
