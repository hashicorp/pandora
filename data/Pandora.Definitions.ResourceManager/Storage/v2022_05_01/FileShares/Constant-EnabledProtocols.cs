using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnabledProtocolsConstant
{
    [Description("NFS")]
    NFS,

    [Description("SMB")]
    SMB,
}
