using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ExpressRouteAuthorizationProvisioningState
    {
        [Description("Failed")]
        Failed,

        [Description("Succeeded")]
        Succeeded,

        [Description("Updating")]
        Updating,
    }
}
