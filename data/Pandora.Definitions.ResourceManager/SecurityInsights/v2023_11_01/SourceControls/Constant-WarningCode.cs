using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WarningCodeConstant
{
    [Description("SourceControl_DeletedWithWarnings")]
    SourceControlDeletedWithWarnings,

    [Description("SourceControlWarning_DeletePipelineFromAzureDevOps")]
    SourceControlWarningDeletePipelineFromAzureDevOps,

    [Description("SourceControlWarning_DeleteRoleAssignment")]
    SourceControlWarningDeleteRoleAssignment,

    [Description("SourceControlWarning_DeleteServicePrincipal")]
    SourceControlWarningDeleteServicePrincipal,

    [Description("SourceControlWarning_DeleteWorkflowAndSecretFromGitHub")]
    SourceControlWarningDeleteWorkflowAndSecretFromGitHub,
}
