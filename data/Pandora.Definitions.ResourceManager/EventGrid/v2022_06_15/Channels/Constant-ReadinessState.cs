using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Channels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadinessStateConstant
{
    [Description("Activated")]
    Activated,

    [Description("NeverActivated")]
    NeverActivated,
}
