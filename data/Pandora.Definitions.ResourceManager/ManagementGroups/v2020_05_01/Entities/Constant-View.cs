using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ViewConstant
{
    [Description("Audit")]
    Audit,

    [Description("FullHierarchy")]
    FullHierarchy,

    [Description("GroupsOnly")]
    GroupsOnly,

    [Description("SubscriptionsOnly")]
    SubscriptionsOnly,
}
