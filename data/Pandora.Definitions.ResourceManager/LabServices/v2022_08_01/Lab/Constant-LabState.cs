using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Lab;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LabStateConstant
{
    [Description("Draft")]
    Draft,

    [Description("Published")]
    Published,

    [Description("Publishing")]
    Publishing,

    [Description("Scaling")]
    Scaling,

    [Description("Syncing")]
    Syncing,
}
