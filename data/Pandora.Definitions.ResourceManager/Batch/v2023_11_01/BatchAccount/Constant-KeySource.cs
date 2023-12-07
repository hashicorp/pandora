using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.BatchAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Microsoft.Batch")]
    MicrosoftPointBatch,

    [Description("Microsoft.KeyVault")]
    MicrosoftPointKeyVault,
}
