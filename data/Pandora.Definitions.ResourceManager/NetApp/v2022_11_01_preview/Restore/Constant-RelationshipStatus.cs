using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.Restore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RelationshipStatusConstant
{
    [Description("Idle")]
    Idle,

    [Description("Transferring")]
    Transferring,
}
