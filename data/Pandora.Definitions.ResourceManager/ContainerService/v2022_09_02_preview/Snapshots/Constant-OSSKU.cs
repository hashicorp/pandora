using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OSSKUConstant
{
    [Description("CBLMariner")]
    CBLMariner,

    [Description("Mariner")]
    Mariner,

    [Description("Ubuntu")]
    Ubuntu,

    [Description("Windows2019")]
    WindowsTwoZeroOneNine,

    [Description("Windows2022")]
    WindowsTwoZeroTwoTwo,
}
