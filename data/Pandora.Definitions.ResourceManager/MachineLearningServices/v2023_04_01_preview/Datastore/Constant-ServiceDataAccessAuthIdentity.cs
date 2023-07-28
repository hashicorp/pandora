using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Datastore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceDataAccessAuthIdentityConstant
{
    [Description("None")]
    None,

    [Description("WorkspaceSystemAssignedIdentity")]
    WorkspaceSystemAssignedIdentity,

    [Description("WorkspaceUserAssignedIdentity")]
    WorkspaceUserAssignedIdentity,
}
