using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.PrivateEndpointConnections
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PrivateEndpointConnectionProvisioningStateConstant
    {
        [Description("Creating")]
        Creating,

        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Succeeded")]
        Succeeded,
    }
}
