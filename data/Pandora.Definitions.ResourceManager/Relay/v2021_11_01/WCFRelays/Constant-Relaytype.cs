using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01.WCFRelays;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RelaytypeConstant
{
    [Description("Http")]
    HTTP,

    [Description("NetTcp")]
    NetTcp,
}
