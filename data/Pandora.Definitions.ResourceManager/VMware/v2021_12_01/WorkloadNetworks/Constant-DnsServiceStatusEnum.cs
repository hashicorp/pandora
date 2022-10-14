using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.WorkloadNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DnsServiceStatusEnumConstant
{
    [Description("FAILURE")]
    FAILURE,

    [Description("SUCCESS")]
    SUCCESS,
}
