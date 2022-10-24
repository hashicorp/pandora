using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.EntityQueries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityTypeConstant
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

    [Description("HuntingBookmark")]
    HuntingBookmark,

    [Description("IP")]
    IP,

    [Description("IoTDevice")]
    IoTDevice,

    [Description("MailCluster")]
    MailCluster,

    [Description("MailMessage")]
    MailMessage,

    [Description("Mailbox")]
    Mailbox,

    [Description("Malware")]
    Malware,

    [Description("Nic")]
    Nic,

    [Description("Process")]
    Process,

    [Description("RegistryKey")]
    RegistryKey,

    [Description("RegistryValue")]
    RegistryValue,

    [Description("SecurityAlert")]
    SecurityAlert,

    [Description("SecurityGroup")]
    SecurityGroup,

    [Description("SubmissionMail")]
    SubmissionMail,

    [Description("URL")]
    URL,
}
