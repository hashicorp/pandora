using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_10_01.ContainerInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogAnalyticsLogTypeConstant
{
    [Description("ContainerInsights")]
    ContainerInsights,

    [Description("ContainerInstanceLogs")]
    ContainerInstanceLogs,
}
