using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PatchOperationStartedByConstant
{
    [Description("Platform")]
    Platform,

    [Description("User")]
    User,
}
