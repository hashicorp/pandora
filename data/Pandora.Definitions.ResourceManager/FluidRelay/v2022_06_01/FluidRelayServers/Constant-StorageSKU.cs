using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_06_01.FluidRelayServers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageSKUConstant
{
    [Description("basic")]
    Basic,

    [Description("standard")]
    Standard,
}
