using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum IscsiTargetAclModeConstant
    {
        [Description("Dynamic")]
        Dynamic,

        [Description("Static")]
        Static,
    }
}
