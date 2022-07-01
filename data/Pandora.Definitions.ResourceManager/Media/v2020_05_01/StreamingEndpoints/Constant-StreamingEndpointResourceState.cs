using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StreamingEndpointResourceStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Running")]
    Running,

    [Description("Scaling")]
    Scaling,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
