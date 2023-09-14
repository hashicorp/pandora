using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Clusters;

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

    [Description("NotSpecified")]
    NotSpecified,

    [Description("NotYetRegistered")]
    NotYetRegistered,
}
