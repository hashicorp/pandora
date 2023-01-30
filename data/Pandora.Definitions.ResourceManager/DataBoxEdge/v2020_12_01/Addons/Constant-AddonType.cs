using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Addons;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AddonTypeConstant
{
    [Description("ArcForKubernetes")]
    ArcForKubernetes,

    [Description("IotEdge")]
    IotEdge,
}
