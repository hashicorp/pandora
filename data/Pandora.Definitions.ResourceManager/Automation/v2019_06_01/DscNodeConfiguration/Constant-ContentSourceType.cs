using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.DscNodeConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentSourceTypeConstant
{
    [Description("embeddedContent")]
    EmbeddedContent,

    [Description("uri")]
    Uri,
}
