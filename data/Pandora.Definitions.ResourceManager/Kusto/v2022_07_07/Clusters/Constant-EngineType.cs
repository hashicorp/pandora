using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EngineTypeConstant
{
    [Description("V3")]
    VThree,

    [Description("V2")]
    VTwo,
}
