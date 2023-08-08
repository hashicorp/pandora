using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MountOptionEnumConstant
{
    [Description("ATTACH")]
    ATTACH,

    [Description("MOUNT")]
    MOUNT,
}
