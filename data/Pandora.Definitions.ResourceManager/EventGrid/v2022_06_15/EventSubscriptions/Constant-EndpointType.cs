using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointTypeConstant
{
    [Description("AzureFunction")]
    AzureFunction,

    [Description("EventHub")]
    EventHub,

    [Description("HybridConnection")]
    HybridConnection,

    [Description("ServiceBusQueue")]
    ServiceBusQueue,

    [Description("ServiceBusTopic")]
    ServiceBusTopic,

    [Description("StorageQueue")]
    StorageQueue,

    [Description("WebHook")]
    WebHook,
}
