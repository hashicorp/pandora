using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.SubAssessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceConstant
{
    [Description("Azure")]
    Azure,

    [Description("OnPremise")]
    OnPremise,

    [Description("OnPremiseSql")]
    OnPremiseSql,
}
