using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.SecurityContacts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertsToAdminsConstant
{
    [Description("Off")]
    Off,

    [Description("On")]
    On,
}
