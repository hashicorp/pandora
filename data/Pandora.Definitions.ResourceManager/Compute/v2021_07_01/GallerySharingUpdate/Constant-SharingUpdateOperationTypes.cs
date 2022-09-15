using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GallerySharingUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharingUpdateOperationTypesConstant
{
    [Description("Add")]
    Add,

    [Description("Remove")]
    Remove,

    [Description("Reset")]
    Reset,
}
