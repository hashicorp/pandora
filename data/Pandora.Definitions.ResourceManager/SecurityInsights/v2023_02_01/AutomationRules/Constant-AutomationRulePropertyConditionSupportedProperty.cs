using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationRulePropertyConditionSupportedPropertyConstant
{
    [Description("AccountAadTenantId")]
    AccountAadTenantId,

    [Description("AccountAadUserId")]
    AccountAadUserId,

    [Description("AccountNTDomain")]
    AccountNTDomain,

    [Description("AccountName")]
    AccountName,

    [Description("AccountObjectGuid")]
    AccountObjectGuid,

    [Description("AccountPUID")]
    AccountPUID,

    [Description("AccountSid")]
    AccountSid,

    [Description("AccountUPNSuffix")]
    AccountUPNSuffix,

    [Description("AlertAnalyticRuleIds")]
    AlertAnalyticRuleIds,

    [Description("AlertProductNames")]
    AlertProductNames,

    [Description("AzureResourceResourceId")]
    AzureResourceResourceId,

    [Description("AzureResourceSubscriptionId")]
    AzureResourceSubscriptionId,

    [Description("CloudApplicationAppId")]
    CloudApplicationAppId,

    [Description("CloudApplicationAppName")]
    CloudApplicationAppName,

    [Description("DNSDomainName")]
    DNSDomainName,

    [Description("FileDirectory")]
    FileDirectory,

    [Description("FileHashValue")]
    FileHashValue,

    [Description("FileName")]
    FileName,

    [Description("HostAzureID")]
    HostAzureID,

    [Description("HostNTDomain")]
    HostNTDomain,

    [Description("HostName")]
    HostName,

    [Description("HostNetBiosName")]
    HostNetBiosName,

    [Description("HostOSVersion")]
    HostOSVersion,

    [Description("IPAddress")]
    IPAddress,

    [Description("IncidentDescription")]
    IncidentDescription,

    [Description("IncidentLabel")]
    IncidentLabel,

    [Description("IncidentProviderName")]
    IncidentProviderName,

    [Description("IncidentRelatedAnalyticRuleIds")]
    IncidentRelatedAnalyticRuleIds,

    [Description("IncidentSeverity")]
    IncidentSeverity,

    [Description("IncidentStatus")]
    IncidentStatus,

    [Description("IncidentTactics")]
    IncidentTactics,

    [Description("IncidentTitle")]
    IncidentTitle,

    [Description("IncidentUpdatedBySource")]
    IncidentUpdatedBySource,

    [Description("IoTDeviceId")]
    IoTDeviceId,

    [Description("IoTDeviceModel")]
    IoTDeviceModel,

    [Description("IoTDeviceName")]
    IoTDeviceName,

    [Description("IoTDeviceOperatingSystem")]
    IoTDeviceOperatingSystem,

    [Description("IoTDeviceType")]
    IoTDeviceType,

    [Description("IoTDeviceVendor")]
    IoTDeviceVendor,

    [Description("MailMessageDeliveryAction")]
    MailMessageDeliveryAction,

    [Description("MailMessageDeliveryLocation")]
    MailMessageDeliveryLocation,

    [Description("MailMessageP1Sender")]
    MailMessagePOneSender,

    [Description("MailMessageP2Sender")]
    MailMessagePTwoSender,

    [Description("MailMessageRecipient")]
    MailMessageRecipient,

    [Description("MailMessageSenderIP")]
    MailMessageSenderIP,

    [Description("MailMessageSubject")]
    MailMessageSubject,

    [Description("MailboxDisplayName")]
    MailboxDisplayName,

    [Description("MailboxPrimaryAddress")]
    MailboxPrimaryAddress,

    [Description("MailboxUPN")]
    MailboxUPN,

    [Description("MalwareCategory")]
    MalwareCategory,

    [Description("MalwareName")]
    MalwareName,

    [Description("ProcessCommandLine")]
    ProcessCommandLine,

    [Description("ProcessId")]
    ProcessId,

    [Description("RegistryKey")]
    RegistryKey,

    [Description("RegistryValueData")]
    RegistryValueData,

    [Description("Url")]
    Url,
}
