using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryConstant
{
    [Description("AuditLogs")]
    AuditLogs,

    [Description("SignInLogs")]
    SignInLogs,
}
