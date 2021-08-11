using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum StateConstant
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
