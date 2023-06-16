using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.FeatureSupport;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportStatusConstant
{
    [Description("DefaultOFF")]
    DefaultOFF,

    [Description("DefaultON")]
    DefaultON,

    [Description("Invalid")]
    Invalid,

    [Description("NotSupported")]
    NotSupported,

    [Description("Supported")]
    Supported,
}
