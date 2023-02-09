using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.CloudEndpointResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChangeDetectionModeConstant
{
    [Description("Default")]
    Default,

    [Description("Recursive")]
    Recursive,
}
