using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoTrackingConfigurationConstant
{
    [Description("disabled")]
    Disabled,

    [Description("sBand")]
    SBand,

    [Description("xBand")]
    XBand,
}
