using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ReplicationLinks;

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
