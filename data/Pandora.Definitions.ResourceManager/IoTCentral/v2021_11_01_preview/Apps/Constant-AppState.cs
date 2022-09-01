using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Apps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppStateConstant
{
    [Description("created")]
    Created,

    [Description("suspended")]
    Suspended,
}
