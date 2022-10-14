using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatastoreStatusConstant
{
    [Description("Accessible")]
    Accessible,

    [Description("Attached")]
    Attached,

    [Description("DeadOrError")]
    DeadOrError,

    [Description("Detached")]
    Detached,

    [Description("Inaccessible")]
    Inaccessible,

    [Description("LostCommunication")]
    LostCommunication,

    [Description("Unknown")]
    Unknown,
}
