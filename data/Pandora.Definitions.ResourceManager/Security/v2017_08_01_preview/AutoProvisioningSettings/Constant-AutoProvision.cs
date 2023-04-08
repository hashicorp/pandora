using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.AutoProvisioningSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoProvisionConstant
{
    [Description("Off")]
    Off,

    [Description("On")]
    On,
}
