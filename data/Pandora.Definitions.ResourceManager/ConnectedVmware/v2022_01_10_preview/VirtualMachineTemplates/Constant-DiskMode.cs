using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskModeConstant
{
    [Description("independent_nonpersistent")]
    IndependentNonpersistent,

    [Description("independent_persistent")]
    IndependentPersistent,

    [Description("persistent")]
    Persistent,
}
