using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentPoolDetailedStatusConstant
{
    [Description("Available")]
    Available,

    [Description("Error")]
    Error,

    [Description("Provisioning")]
    Provisioning,
}
