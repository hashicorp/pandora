using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Skus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LabServicesSkuTierConstant
{
    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
