using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Containers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerStatusConstant
{
    [Description("NeedsAttention")]
    NeedsAttention,

    [Description("OK")]
    OK,

    [Description("Offline")]
    Offline,

    [Description("Unknown")]
    Unknown,

    [Description("Updating")]
    Updating,
}
