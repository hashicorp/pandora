using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;

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
