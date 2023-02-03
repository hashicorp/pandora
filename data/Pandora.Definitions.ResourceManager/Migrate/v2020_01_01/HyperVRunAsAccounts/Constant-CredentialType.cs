using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVRunAsAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialTypeConstant
{
    [Description("HyperVFabric")]
    HyperVFabric,

    [Description("LinuxGuest")]
    LinuxGuest,

    [Description("LinuxServer")]
    LinuxServer,

    [Description("VMwareFabric")]
    VMwareFabric,

    [Description("WindowsGuest")]
    WindowsGuest,

    [Description("WindowsServer")]
    WindowsServer,
}
