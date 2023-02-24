using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PipelineRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunQueryOrderConstant
{
    [Description("ASC")]
    ASC,

    [Description("DESC")]
    DESC,
}
