using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProvisioningState
    {
        [Description("Canceled")]
        Canceled,

        [Description("Creating")]
        Creating,

        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Moving")]
        Moving,

        [Description("Running")]
        Running,

        [Description("Succeeded")]
        Succeeded,

        [Description("Unknown")]
        Unknown,

        [Description("Updating")]
        Updating,
    }
}
