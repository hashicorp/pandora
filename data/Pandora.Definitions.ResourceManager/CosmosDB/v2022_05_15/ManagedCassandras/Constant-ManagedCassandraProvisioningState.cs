using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.ManagedCassandras;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedCassandraProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
