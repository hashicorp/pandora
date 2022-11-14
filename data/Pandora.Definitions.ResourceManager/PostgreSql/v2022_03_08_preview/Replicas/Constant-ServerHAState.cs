using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerHAStateConstant
{
    [Description("CreatingStandby")]
    CreatingStandby,

    [Description("FailingOver")]
    FailingOver,

    [Description("Healthy")]
    Healthy,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("RemovingStandby")]
    RemovingStandby,

    [Description("ReplicatingData")]
    ReplicatingData,
}
