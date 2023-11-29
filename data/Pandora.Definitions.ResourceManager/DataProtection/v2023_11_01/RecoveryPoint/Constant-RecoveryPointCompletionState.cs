using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.RecoveryPoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointCompletionStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Partial")]
    Partial,
}
