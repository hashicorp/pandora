using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationLinkTypeConstant
{
    [Description("GEO")]
    GEO,

    [Description("NAMED")]
    NAMED,

    [Description("STANDBY")]
    STANDBY,
}
