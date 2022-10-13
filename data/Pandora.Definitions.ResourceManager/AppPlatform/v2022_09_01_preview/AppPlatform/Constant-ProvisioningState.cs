using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("MoveFailed")]
    MoveFailed,

    [Description("Moved")]
    Moved,

    [Description("Moving")]
    Moving,

    [Description("Starting")]
    Starting,

    [Description("Stopping")]
    Stopping,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
