using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Logger;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoggerTypeConstant
{
    [Description("applicationInsights")]
    ApplicationInsights,

    [Description("azureEventHub")]
    AzureEventHub,

    [Description("azureMonitor")]
    AzureMonitor,
}
