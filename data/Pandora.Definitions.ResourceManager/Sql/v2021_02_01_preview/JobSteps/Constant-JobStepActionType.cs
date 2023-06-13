using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobSteps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStepActionTypeConstant
{
    [Description("TSql")]
    TSql,
}
