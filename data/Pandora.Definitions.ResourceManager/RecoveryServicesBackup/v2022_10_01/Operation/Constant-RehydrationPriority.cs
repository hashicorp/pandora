using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.Operation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RehydrationPriorityConstant
{
    [Description("High")]
    High,

    [Description("Standard")]
    Standard,
}
