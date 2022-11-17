using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.Updates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AvailabilityTypeConstant
{
    [Description("Local")]
    Local,

    [Description("Notify")]
    Notify,

    [Description("Online")]
    Online,
}
