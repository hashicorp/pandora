using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureResourceTypeConstant
{
    [Description("TrafficManager")]
    TrafficManager,

    [Description("Website")]
    Website,
}
