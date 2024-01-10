using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.SnapshotPolicyListVolumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CoolAccessRetrievalPolicyConstant
{
    [Description("Default")]
    Default,

    [Description("Never")]
    Never,

    [Description("OnRead")]
    OnRead,
}
