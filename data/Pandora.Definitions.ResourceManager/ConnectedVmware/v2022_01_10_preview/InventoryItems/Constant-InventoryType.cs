using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.InventoryItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InventoryTypeConstant
{
    [Description("Cluster")]
    Cluster,

    [Description("Datastore")]
    Datastore,

    [Description("Host")]
    Host,

    [Description("ResourcePool")]
    ResourcePool,

    [Description("VirtualMachine")]
    VirtualMachine,

    [Description("VirtualMachineTemplate")]
    VirtualMachineTemplate,

    [Description("VirtualNetwork")]
    VirtualNetwork,
}
