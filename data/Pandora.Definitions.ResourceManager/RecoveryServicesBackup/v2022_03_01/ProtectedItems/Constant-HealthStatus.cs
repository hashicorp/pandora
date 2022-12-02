using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.ProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStatusConstant
{
    [Description("ActionRequired")]
    ActionRequired,

    [Description("ActionSuggested")]
    ActionSuggested,

    [Description("Invalid")]
    Invalid,

    [Description("Passed")]
    Passed,
}
