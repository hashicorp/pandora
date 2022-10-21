using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabaseRoutingConstant
{
    [Description("Multi")]
    Multi,

    [Description("Single")]
    Single,
}
