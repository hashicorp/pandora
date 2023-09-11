using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkTypeConstant
{
    [Description("External")]
    External,

    [Description("Internal")]
    Internal,

    [Description("None")]
    None,
}
