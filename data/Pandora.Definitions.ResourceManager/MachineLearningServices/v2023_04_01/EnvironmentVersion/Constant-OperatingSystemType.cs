using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.EnvironmentVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemTypeConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
