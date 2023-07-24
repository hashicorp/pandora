using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureResourceTypeConstant
{
    [Description("TrafficManager")]
    TrafficManager,

    [Description("Website")]
    Website,
}
