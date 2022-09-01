using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_05_26.FluidRelayServers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CmkIdentityTypeConstant
{
    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
