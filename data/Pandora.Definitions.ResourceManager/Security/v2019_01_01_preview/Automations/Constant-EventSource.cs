using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventSourceConstant
{
    [Description("Alerts")]
    Alerts,

    [Description("Assessments")]
    Assessments,

    [Description("AssessmentsSnapshot")]
    AssessmentsSnapshot,

    [Description("RegulatoryComplianceAssessment")]
    RegulatoryComplianceAssessment,

    [Description("RegulatoryComplianceAssessmentSnapshot")]
    RegulatoryComplianceAssessmentSnapshot,

    [Description("SecureScoreControls")]
    SecureScoreControls,

    [Description("SecureScoreControlsSnapshot")]
    SecureScoreControlsSnapshot,

    [Description("SecureScores")]
    SecureScores,

    [Description("SecureScoresSnapshot")]
    SecureScoresSnapshot,

    [Description("SubAssessments")]
    SubAssessments,

    [Description("SubAssessmentsSnapshot")]
    SubAssessmentsSnapshot,
}
