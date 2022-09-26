using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskCreateOptionTypesConstant
{
    [Description("Attach")]
    Attach,

    [Description("Empty")]
    Empty,

    [Description("FromImage")]
    FromImage,
}
