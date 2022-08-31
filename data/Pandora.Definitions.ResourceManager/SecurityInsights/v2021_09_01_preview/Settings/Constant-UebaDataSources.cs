using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Settings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UebaDataSourcesConstant
{
    [Description("AuditLogs")]
    AuditLogs,

    [Description("AzureActivity")]
    AzureActivity,

    [Description("SecurityEvent")]
    SecurityEvent,

    [Description("SigninLogs")]
    SigninLogs,
}
