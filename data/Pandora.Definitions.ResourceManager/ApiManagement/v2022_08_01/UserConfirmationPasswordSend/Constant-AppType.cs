using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.UserConfirmationPasswordSend;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppTypeConstant
{
    [Description("developerPortal")]
    DeveloperPortal,

    [Description("portal")]
    Portal,
}
