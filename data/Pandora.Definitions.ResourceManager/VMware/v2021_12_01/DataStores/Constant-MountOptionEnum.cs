using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MountOptionEnumConstant
{
    [Description("ATTACH")]
    ATTACH,

    [Description("MOUNT")]
    MOUNT,
}
