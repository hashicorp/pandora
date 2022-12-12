using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VersionStateConstant
{
    [Description("Active")]
    Active,

    [Description("Deprecated")]
    Deprecated,

    [Description("Preview")]
    Preview,

    [Description("Unknown")]
    Unknown,

    [Description("Validating")]
    Validating,

    [Description("ValidationFailed")]
    ValidationFailed,
}
