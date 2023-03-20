using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPSupportedSku;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPHighAvailabilityTypeConstant
{
    [Description("AvailabilitySet")]
    AvailabilitySet,

    [Description("AvailabilityZone")]
    AvailabilityZone,
}
