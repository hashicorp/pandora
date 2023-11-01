using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_09_01.TestLines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
