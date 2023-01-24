using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionKeySourceTypeConstant
{
    [Description("Microsoft.Automation")]
    MicrosoftPointAutomation,

    [Description("Microsoft.Keyvault")]
    MicrosoftPointKeyvault,
}
