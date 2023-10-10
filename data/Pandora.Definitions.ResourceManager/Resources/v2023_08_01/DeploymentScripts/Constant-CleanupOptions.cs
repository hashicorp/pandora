using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_08_01.DeploymentScripts;

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
