using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.GET;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Deleting")]
    Deleting,

    [Description("Deploying")]
    Deploying,

    [Description("Failed")]
    Failed,

    [Description("FailedToStart")]
    FailedToStart,

    [Description("FailedToStop")]
    FailedToStop,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Succeeded")]
    Succeeded,
}
