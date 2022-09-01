using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SourceControl;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TokenTypeConstant
{
    [Description("Oauth")]
    Oauth,

    [Description("PersonalAccessToken")]
    PersonalAccessToken,
}
