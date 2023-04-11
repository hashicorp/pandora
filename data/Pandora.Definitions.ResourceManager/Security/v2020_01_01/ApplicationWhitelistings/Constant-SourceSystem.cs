using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceSystemConstant
{
    [Description("Azure_AppLocker")]
    AzureAppLocker,

    [Description("Azure_AuditD")]
    AzureAuditD,

    [Description("NonAzure_AppLocker")]
    NonAzureAppLocker,

    [Description("NonAzure_AuditD")]
    NonAzureAuditD,

    [Description("None")]
    None,
}
