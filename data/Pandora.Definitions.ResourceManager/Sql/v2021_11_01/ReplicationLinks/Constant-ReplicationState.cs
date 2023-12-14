using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationStateConstant
{
    [Description("CATCH_UP")]
    CATCHUP,

    [Description("PENDING")]
    PENDING,

    [Description("SEEDING")]
    SEEDING,

    [Description("SUSPENDED")]
    SUSPENDED,
}
