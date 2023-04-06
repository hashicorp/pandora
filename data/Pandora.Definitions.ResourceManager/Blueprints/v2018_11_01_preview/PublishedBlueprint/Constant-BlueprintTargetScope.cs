using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.PublishedBlueprint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BlueprintTargetScopeConstant
{
    [Description("managementGroup")]
    ManagementGroup,

    [Description("subscription")]
    Subscription,
}
