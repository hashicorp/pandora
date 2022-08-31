using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Servicelinker;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetServiceTypeConstant
{
    [Description("AzureResource")]
    AzureResource,

    [Description("ConfluentBootstrapServer")]
    ConfluentBootstrapServer,

    [Description("ConfluentSchemaRegistry")]
    ConfluentSchemaRegistry,
}
