using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.EnvironmentVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoRebuildSettingConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("OnBaseImageUpdate")]
    OnBaseImageUpdate,
}
