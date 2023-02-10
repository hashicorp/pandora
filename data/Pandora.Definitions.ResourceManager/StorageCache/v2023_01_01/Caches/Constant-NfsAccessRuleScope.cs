using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NfsAccessRuleScopeConstant
{
    [Description("default")]
    Default,

    [Description("host")]
    Host,

    [Description("network")]
    Network,
}
