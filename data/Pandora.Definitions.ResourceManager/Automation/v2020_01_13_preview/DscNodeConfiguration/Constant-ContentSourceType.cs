using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.DscNodeConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentSourceTypeConstant
{
    [Description("embeddedContent")]
    EmbeddedContent,

    [Description("uri")]
    Uri,
}
