using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.JobSteps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStepActionTypeConstant
{
    [Description("TSql")]
    TSql,
}
