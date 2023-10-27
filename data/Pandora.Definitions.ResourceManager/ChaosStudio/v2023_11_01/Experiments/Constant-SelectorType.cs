using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_11_01.Experiments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorTypeConstant
{
    [Description("List")]
    List,

    [Description("Query")]
    Query,
}
