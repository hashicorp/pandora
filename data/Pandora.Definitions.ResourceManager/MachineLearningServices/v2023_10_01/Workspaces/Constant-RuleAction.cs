using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RuleActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
