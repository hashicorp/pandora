using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationThresholdTypeConstant
{
    [Description("CountSuccess")]
    CountSuccess,

    [Description("PercentSuccess")]
    PercentSuccess,
}
