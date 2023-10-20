using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Null")]
    Null,

    [Description("Premium")]
    Premium,

    [Description("Spot")]
    Spot,

    [Description("Standard")]
    Standard,
}
