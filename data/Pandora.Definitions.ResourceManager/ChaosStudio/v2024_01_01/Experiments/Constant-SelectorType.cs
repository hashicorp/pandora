using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2024_01_01.Experiments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorTypeConstant
{
    [Description("List")]
    List,

    [Description("Query")]
    Query,
}
