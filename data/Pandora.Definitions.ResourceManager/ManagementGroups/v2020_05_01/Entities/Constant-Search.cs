using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SearchConstant
{
    [Description("AllowedChildren")]
    AllowedChildren,

    [Description("AllowedParents")]
    AllowedParents,

    [Description("ChildrenOnly")]
    ChildrenOnly,

    [Description("ParentAndFirstLevelChildren")]
    ParentAndFirstLevelChildren,

    [Description("ParentOnly")]
    ParentOnly,
}
