using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_09_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterNodeTypeConstant
{
    [Description("FirstParty")]
    FirstParty,

    [Description("ThirdParty")]
    ThirdParty,
}
