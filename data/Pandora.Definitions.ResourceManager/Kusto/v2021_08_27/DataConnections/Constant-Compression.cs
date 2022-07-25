using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CompressionConstant
{
    [Description("GZip")]
    GZip,

    [Description("None")]
    None,
}
