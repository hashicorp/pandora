using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BypassConstant
{
    [Description("AzureServices")]
    AzureServices,

    [Description("Logging")]
    Logging,

    [Description("Metrics")]
    Metrics,

    [Description("None")]
    None,
}
