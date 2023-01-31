using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Shares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClientPermissionTypeConstant
{
    [Description("NoAccess")]
    NoAccess,

    [Description("ReadOnly")]
    ReadOnly,

    [Description("ReadWrite")]
    ReadWrite,
}
