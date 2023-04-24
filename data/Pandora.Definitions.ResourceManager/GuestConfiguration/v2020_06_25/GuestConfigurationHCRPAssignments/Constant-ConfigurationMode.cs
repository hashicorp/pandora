using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationHCRPAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationModeConstant
{
    [Description("ApplyAndAutoCorrect")]
    ApplyAndAutoCorrect,

    [Description("ApplyAndMonitor")]
    ApplyAndMonitor,

    [Description("ApplyOnly")]
    ApplyOnly,
}
