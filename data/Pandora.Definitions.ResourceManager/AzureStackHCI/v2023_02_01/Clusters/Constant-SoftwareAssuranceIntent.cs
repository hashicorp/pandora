using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoftwareAssuranceIntentConstant
{
    [Description("Disable")]
    Disable,

    [Description("Enable")]
    Enable,
}
