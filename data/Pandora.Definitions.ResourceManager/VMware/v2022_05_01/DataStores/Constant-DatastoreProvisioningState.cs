using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatastoreProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Cancelled")]
    Cancelled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
