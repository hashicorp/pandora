using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.VolumesReplication;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RelationshipStatusConstant
{
    [Description("Idle")]
    Idle,

    [Description("Transferring")]
    Transferring,
}
