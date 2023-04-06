using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.Assignment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentDeleteBehaviorConstant
{
    [Description("all")]
    All,

    [Description("none")]
    None,
}
