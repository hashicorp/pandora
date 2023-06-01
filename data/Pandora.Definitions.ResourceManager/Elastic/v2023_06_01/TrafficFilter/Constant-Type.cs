using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.TrafficFilter;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("azure_private_endpoint")]
    AzurePrivateEndpoint,

    [Description("ip")]
    IP,
}
