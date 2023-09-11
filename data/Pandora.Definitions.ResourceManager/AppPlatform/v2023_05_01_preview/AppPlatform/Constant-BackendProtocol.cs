using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackendProtocolConstant
{
    [Description("Default")]
    Default,

    [Description("GRPC")]
    GRPC,
}
