using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnabledProtocolsConstant
{
    [Description("NFS")]
    NFS,

    [Description("SMB")]
    SMB,
}
