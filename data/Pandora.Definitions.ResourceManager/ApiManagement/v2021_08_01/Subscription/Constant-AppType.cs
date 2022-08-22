using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Subscription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppTypeConstant
{
    [Description("developerPortal")]
    DeveloperPortal,

    [Description("portal")]
    Portal,
}
