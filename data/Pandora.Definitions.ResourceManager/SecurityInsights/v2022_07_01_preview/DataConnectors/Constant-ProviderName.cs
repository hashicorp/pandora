using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.DataConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProviderNameConstant
{
    [Description("Microsoft.Authorization/policyAssignments")]
    MicrosoftPointAuthorizationPolicyAssignments,

    [Description("Microsoft.OperationalInsights/solutions")]
    MicrosoftPointOperationalInsightsSolutions,

    [Description("Microsoft.OperationalInsights/workspaces")]
    MicrosoftPointOperationalInsightsWorkspaces,

    [Description("Microsoft.OperationalInsights/workspaces/datasources")]
    MicrosoftPointOperationalInsightsWorkspacesDatasources,

    [Description("Microsoft.OperationalInsights/workspaces/sharedKeys")]
    MicrosoftPointOperationalInsightsWorkspacesSharedKeys,

    [Description("microsoft.aadiam/diagnosticSettings")]
    MicrosoftPointaadiamDiagnosticSettings,
}
