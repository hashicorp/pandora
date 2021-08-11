using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProvisioningStateConstant
    {
        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Paused")]
        Paused,

        [Description("Pausing")]
        Pausing,

        [Description("Preparing")]
        Preparing,

        [Description("Provisioning")]
        Provisioning,

        [Description("Resuming")]
        Resuming,

        [Description("Scaling")]
        Scaling,

        [Description("Succeeded")]
        Succeeded,

        [Description("Suspended")]
        Suspended,

        [Description("Suspending")]
        Suspending,

        [Description("Updating")]
        Updating,
    }
}
