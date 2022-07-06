using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EngineTypeConstant
{
    [Description("V3")]
    VThree,

    [Description("V2")]
    VTwo,
}
