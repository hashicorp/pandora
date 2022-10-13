using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_09_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("ConnectedRecently")]
    ConnectedRecently,

    [Description("Disconnected")]
    Disconnected,

    [Description("Error")]
    Error,

    [Description("NotConnectedRecently")]
    NotConnectedRecently,

    [Description("NotYetRegistered")]
    NotYetRegistered,
}
