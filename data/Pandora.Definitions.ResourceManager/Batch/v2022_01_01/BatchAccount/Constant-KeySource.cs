using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.BatchAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Microsoft.Batch")]
    MicrosoftPointBatch,

    [Description("Microsoft.KeyVault")]
    MicrosoftPointKeyVault,
}
