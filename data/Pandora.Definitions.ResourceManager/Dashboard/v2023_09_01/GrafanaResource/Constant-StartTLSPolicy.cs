using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dashboard.v2023_09_01.GrafanaResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StartTLSPolicyConstant
{
    [Description("MandatoryStartTLS")]
    MandatoryStartTLS,

    [Description("NoStartTLS")]
    NoStartTLS,

    [Description("OpportunisticStartTLS")]
    OpportunisticStartTLS,
}
