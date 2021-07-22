using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum RoleDisasterRecovery
    {
        [Description("Primary")]
        Primary,

        [Description("PrimaryNotReplicating")]
        PrimaryNotReplicating,

        [Description("Secondary")]
        Secondary,
    }
}
