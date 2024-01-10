using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.MaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("First")]
    First,

    [Description("Fourth")]
    Fourth,

    [Description("Last")]
    Last,

    [Description("Second")]
    Second,

    [Description("Third")]
    Third,
}
