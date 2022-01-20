using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerHaStateConstant
{
    [Description("CreatingStandby")]
    CreatingStandby,

    [Description("FailingOver")]
    FailingOver,

    [Description("Healthy")]
    Healthy,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("NotSync")]
    NotSync,

    [Description("RemovingStandby")]
    RemovingStandby,

    [Description("ReplicatingData")]
    ReplicatingData,
}
