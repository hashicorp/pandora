using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Services
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ServiceKindConstant
    {
        [Description("Stateful")]
        Stateful,

        [Description("Stateless")]
        Stateless,
    }
}
