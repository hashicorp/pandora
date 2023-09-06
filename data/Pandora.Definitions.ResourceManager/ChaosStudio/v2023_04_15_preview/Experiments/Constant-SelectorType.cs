using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_04_15_preview.Experiments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelectorTypeConstant
{
    [Description("List")]
    List,

    [Description("Query")]
    Query,
}
