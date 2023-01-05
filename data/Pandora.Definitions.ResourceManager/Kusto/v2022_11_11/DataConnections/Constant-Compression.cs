using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CompressionConstant
{
    [Description("GZip")]
    GZip,

    [Description("None")]
    None,
}
