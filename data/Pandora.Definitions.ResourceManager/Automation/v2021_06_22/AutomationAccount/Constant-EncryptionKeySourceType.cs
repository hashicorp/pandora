using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionKeySourceTypeConstant
{
    [Description("Microsoft.Automation")]
    MicrosoftPointAutomation,

    [Description("Microsoft.Keyvault")]
    MicrosoftPointKeyvault,
}
