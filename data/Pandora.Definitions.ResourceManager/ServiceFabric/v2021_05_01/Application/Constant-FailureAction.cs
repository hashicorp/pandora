using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Application
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum FailureActionConstant
    {
        [Description("Manual")]
        Manual,

        [Description("Rollback")]
        Rollback,
    }
}
