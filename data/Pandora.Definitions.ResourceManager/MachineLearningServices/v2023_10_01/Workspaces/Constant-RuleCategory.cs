using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RuleCategoryConstant
{
    [Description("Recommended")]
    Recommended,

    [Description("Required")]
    Required,

    [Description("UserDefined")]
    UserDefined,
}
