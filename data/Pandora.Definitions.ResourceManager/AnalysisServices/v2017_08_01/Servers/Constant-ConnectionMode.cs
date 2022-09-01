using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionModeConstant
{
    [Description("All")]
    All,

    [Description("ReadOnly")]
    ReadOnly,
}
