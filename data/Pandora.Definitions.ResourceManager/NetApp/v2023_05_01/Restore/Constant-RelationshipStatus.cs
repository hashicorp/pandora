using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.Restore;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RelationshipStatusConstant
{
    [Description("Idle")]
    Idle,

    [Description("Transferring")]
    Transferring,
}
