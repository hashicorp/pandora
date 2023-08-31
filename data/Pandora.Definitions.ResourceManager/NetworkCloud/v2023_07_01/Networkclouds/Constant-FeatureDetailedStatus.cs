using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureDetailedStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Running")]
    Running,

    [Description("Unknown")]
    Unknown,
}
