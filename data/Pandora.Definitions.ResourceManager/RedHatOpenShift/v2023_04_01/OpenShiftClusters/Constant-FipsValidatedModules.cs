using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2023_04_01.OpenShiftClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FipsValidatedModulesConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
