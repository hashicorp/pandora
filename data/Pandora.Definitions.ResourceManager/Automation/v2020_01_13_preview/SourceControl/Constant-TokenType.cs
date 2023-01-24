using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.SourceControl;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TokenTypeConstant
{
    [Description("Oauth")]
    Oauth,

    [Description("PersonalAccessToken")]
    PersonalAccessToken,
}
