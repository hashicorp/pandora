using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NfsAccessRuleAccessConstant
{
    [Description("no")]
    No,

    [Description("ro")]
    Ro,

    [Description("rw")]
    Rw,
}
