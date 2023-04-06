using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.PublishedArtifact;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArtifactKindConstant
{
    [Description("policyAssignment")]
    PolicyAssignment,

    [Description("roleAssignment")]
    RoleAssignment,

    [Description("template")]
    Template,
}
