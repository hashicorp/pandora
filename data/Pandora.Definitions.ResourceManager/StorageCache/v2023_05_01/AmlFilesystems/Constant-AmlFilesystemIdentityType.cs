using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AmlFilesystemIdentityTypeConstant
{
    [Description("None")]
    None,

    [Description("UserAssigned")]
    UserAssigned,
}
