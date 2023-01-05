using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationTypeConstant
{
    [Description("DeepValidation")]
    DeepValidation,

    [Description("ShallowValidation")]
    ShallowValidation,
}
