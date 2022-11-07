using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.DeploymentScripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CleanupOptionsConstant
{
    [Description("Always")]
    Always,

    [Description("OnExpiration")]
    OnExpiration,

    [Description("OnSuccess")]
    OnSuccess,
}
