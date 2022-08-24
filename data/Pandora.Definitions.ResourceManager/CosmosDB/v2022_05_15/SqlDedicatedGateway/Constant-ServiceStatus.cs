using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.SqlDedicatedGateway;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceStatusConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Error")]
    Error,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Updating")]
    Updating,
}
