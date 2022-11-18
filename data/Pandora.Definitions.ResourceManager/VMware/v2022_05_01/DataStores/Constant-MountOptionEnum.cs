using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MountOptionEnumConstant
{
    [Description("ATTACH")]
    ATTACH,

    [Description("MOUNT")]
    MOUNT,
}
