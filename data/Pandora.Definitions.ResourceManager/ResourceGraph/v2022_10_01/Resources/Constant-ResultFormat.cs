using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResultFormatConstant
{
    [Description("objectArray")]
    ObjectArray,

    [Description("table")]
    Table,
}
