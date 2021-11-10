using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ServicePackageActivationModeConstant
    {
        [Description("ExclusiveProcess")]
        ExclusiveProcess,

        [Description("SharedProcess")]
        SharedProcess,
    }
}
