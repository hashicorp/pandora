using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ManagedNetwork;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedNetworkStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Inactive")]
    Inactive,
}
