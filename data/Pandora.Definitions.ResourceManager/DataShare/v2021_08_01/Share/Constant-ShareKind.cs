using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShareKindConstant
{
    [Description("CopyBased")]
    CopyBased,

    [Description("InPlace")]
    InPlace,
}
