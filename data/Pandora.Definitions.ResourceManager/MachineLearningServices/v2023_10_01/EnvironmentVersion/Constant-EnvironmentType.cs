using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.EnvironmentVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnvironmentTypeConstant
{
    [Description("Curated")]
    Curated,

    [Description("UserCreated")]
    UserCreated,
}
