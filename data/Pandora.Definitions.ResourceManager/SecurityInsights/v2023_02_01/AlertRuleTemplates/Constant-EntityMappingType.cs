using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityMappingTypeConstant
{
    [Description("Account")]
    Account,

    [Description("AzureResource")]
    AzureResource,

    [Description("CloudApplication")]
    CloudApplication,

    [Description("DNS")]
    DNS,

    [Description("File")]
    File,

    [Description("FileHash")]
    FileHash,

    [Description("Host")]
    Host,

    [Description("IP")]
    IP,

    [Description("MailCluster")]
    MailCluster,

    [Description("MailMessage")]
    MailMessage,

    [Description("Mailbox")]
    Mailbox,

    [Description("Malware")]
    Malware,

    [Description("Process")]
    Process,

    [Description("RegistryKey")]
    RegistryKey,

    [Description("RegistryValue")]
    RegistryValue,

    [Description("SecurityGroup")]
    SecurityGroup,

    [Description("SubmissionMail")]
    SubmissionMail,

    [Description("URL")]
    URL,
}
