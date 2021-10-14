using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.GET
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

        [Description("Updating")]
        Updating,
    }
}
