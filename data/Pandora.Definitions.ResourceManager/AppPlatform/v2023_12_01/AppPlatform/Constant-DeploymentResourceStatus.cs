using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentResourceStatusConstant
{
    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,
}
