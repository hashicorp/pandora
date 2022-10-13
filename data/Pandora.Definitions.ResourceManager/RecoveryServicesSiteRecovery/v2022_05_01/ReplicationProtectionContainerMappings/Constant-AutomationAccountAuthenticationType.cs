using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectionContainerMappings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationAccountAuthenticationTypeConstant
{
    [Description("RunAsAccount")]
    RunAsAccount,

    [Description("SystemAssignedIdentity")]
    SystemAssignedIdentity,
}
