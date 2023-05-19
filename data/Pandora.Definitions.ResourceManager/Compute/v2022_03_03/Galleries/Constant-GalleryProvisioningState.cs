using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.Galleries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GalleryProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Migrating")]
    Migrating,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
