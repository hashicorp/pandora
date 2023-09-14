using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiscoveryScopeStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("DiscoveryFailed")]
    DiscoveryFailed,

    [Description("DiscoveryInProgress")]
    DiscoveryInProgress,

    [Description("DiscoveryNotStarted")]
    DiscoveryNotStarted,

    [Description("DiscoveryPartiallySucceded")]
    DiscoveryPartiallySucceded,

    [Description("DiscoverySucceeded")]
    DiscoverySucceeded,

    [Description("DiscoverySucceededAtleastOnce")]
    DiscoverySucceededAtleastOnce,

    [Description("RunAsAccountNotAssociated")]
    RunAsAccountNotAssociated,
}
