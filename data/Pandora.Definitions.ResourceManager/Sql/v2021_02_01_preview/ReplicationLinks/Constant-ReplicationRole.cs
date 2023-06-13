using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ReplicationLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationRoleConstant
{
    [Description("Copy")]
    Copy,

    [Description("NonReadableSecondary")]
    NonReadableSecondary,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("Source")]
    Source,
}
