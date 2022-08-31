using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.IncidentBookmarks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EntityKindConstant
{
    [Description("Account")]
    Account,

    [Description("AzureResource")]
    AzureResource,

    [Description("Bookmark")]
    Bookmark,

    [Description("CloudApplication")]
    CloudApplication,

    [Description("DnsResolution")]
    DnsResolution,

    [Description("File")]
    File,

    [Description("FileHash")]
    FileHash,

    [Description("Host")]
    Host,

    [Description("Ip")]
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

    [Description("Url")]
    Url,
}
