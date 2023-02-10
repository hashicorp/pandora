using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_06_01.PolicyAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorKindConstant
{
    [Description("policyDefinitionReferenceId")]
    PolicyDefinitionReferenceId,

    [Description("resourceLocation")]
    ResourceLocation,

    [Description("resourceType")]
    ResourceType,

    [Description("resourceWithoutLocation")]
    ResourceWithoutLocation,
}
