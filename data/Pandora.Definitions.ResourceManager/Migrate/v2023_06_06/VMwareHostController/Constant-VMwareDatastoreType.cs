using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.VMwareHostController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMwareDatastoreTypeConstant
{
    [Description("CIFS")]
    CIFS,

    [Description("NFS")]
    NFS,

    [Description("NFS41")]
    NFSFourOne,

    [Description("PMEM")]
    PMEM,

    [Description("Unknown")]
    Unknown,

    [Description("VFFS")]
    VFFS,

    [Description("VMFS")]
    VMFS,

    [Description("VSAN")]
    VSAN,

    [Description("VVOL")]
    VVOL,
}
