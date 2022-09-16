using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_03_01.CognitiveServicesAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Microsoft.CognitiveServices")]
    MicrosoftPointCognitiveServices,

    [Description("Microsoft.KeyVault")]
    MicrosoftPointKeyVault,
}
