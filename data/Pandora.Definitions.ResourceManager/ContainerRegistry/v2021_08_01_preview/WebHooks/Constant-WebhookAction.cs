using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.WebHooks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebhookActionConstant
{
    [Description("chart_delete")]
    ChartDelete,

    [Description("chart_push")]
    ChartPush,

    [Description("delete")]
    Delete,

    [Description("push")]
    Push,

    [Description("quarantine")]
    Quarantine,
}
