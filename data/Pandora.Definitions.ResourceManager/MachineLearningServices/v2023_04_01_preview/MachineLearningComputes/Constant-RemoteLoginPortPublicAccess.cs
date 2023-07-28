using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RemoteLoginPortPublicAccessConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("NotSpecified")]
    NotSpecified,
}
