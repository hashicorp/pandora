using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CreatedByTypeConstant
    {
        [Description("Application")]
        Application,

        [Description("Key")]
        Key,

        [Description("ManagedIdentity")]
        ManagedIdentity,

        [Description("User")]
        User,
    }
}
