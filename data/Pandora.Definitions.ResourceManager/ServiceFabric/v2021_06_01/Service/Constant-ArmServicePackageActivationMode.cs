using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Service;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ArmServicePackageActivationModeConstant
{
    [Description("ExclusiveProcess")]
    ExclusiveProcess,

    [Description("SharedProcess")]
    SharedProcess,
}
