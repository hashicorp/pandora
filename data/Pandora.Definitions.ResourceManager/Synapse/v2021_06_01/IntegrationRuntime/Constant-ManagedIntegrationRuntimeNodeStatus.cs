using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedIntegrationRuntimeNodeStatusConstant
{
    [Description("Available")]
    Available,

    [Description("Recycling")]
    Recycling,

    [Description("Starting")]
    Starting,

    [Description("Unavailable")]
    Unavailable,
}
