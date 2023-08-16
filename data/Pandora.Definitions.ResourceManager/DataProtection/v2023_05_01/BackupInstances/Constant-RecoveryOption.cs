using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryOptionConstant
{
    [Description("FailIfExists")]
    FailIfExists,
}
