using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RehydrationPriorityConstant
{
    [Description("High")]
    High,

    [Description("Invalid")]
    Invalid,

    [Description("Standard")]
    Standard,
}
