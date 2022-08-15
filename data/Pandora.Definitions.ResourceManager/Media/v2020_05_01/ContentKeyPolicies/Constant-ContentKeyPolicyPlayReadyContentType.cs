using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentKeyPolicyPlayReadyContentTypeConstant
{
    [Description("UltraVioletDownload")]
    UltraVioletDownload,

    [Description("UltraVioletStreaming")]
    UltraVioletStreaming,

    [Description("Unknown")]
    Unknown,

    [Description("Unspecified")]
    Unspecified,
}
