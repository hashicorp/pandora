using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.DisasterRecoveryConfigs
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum RoleDisasterRecoveryConstant
    {
        [Description("Primary")]
        Primary,

        [Description("PrimaryNotReplicating")]
        PrimaryNotReplicating,

        [Description("Secondary")]
        Secondary,
    }
}
