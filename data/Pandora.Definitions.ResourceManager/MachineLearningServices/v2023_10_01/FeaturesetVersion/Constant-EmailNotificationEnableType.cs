using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.FeaturesetVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EmailNotificationEnableTypeConstant
{
    [Description("JobCancelled")]
    JobCancelled,

    [Description("JobCompleted")]
    JobCompleted,

    [Description("JobFailed")]
    JobFailed,
}
