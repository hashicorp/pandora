using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Subscription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppTypeConstant
{
    [Description("developerPortal")]
    DeveloperPortal,

    [Description("portal")]
    Portal,
}
