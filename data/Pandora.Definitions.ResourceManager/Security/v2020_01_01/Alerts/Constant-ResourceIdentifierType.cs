using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceIdentifierTypeConstant
{
    [Description("AzureResource")]
    AzureResource,

    [Description("LogAnalytics")]
    LogAnalytics,
}
