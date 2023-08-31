using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterMetricsConfigurationDetailedStatusConstant
{
    [Description("Applied")]
    Applied,

    [Description("Error")]
    Error,

    [Description("Processing")]
    Processing,
}
