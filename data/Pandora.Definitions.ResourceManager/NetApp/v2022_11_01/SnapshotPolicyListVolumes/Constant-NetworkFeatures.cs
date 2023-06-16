using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.SnapshotPolicyListVolumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkFeaturesConstant
{
    [Description("Basic")]
    Basic,

    [Description("Standard")]
    Standard,
}
