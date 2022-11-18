using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_06_01.FluidRelayServers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyNameConstant
{
    [Description("key1")]
    KeyOne,

    [Description("key2")]
    KeyTwo,
}
